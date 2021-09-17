using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanHelper
{
    public static class MetodosDicomRT
    {
        public static int numeroDeTratamientos(string carpetaPaciente)
        {
            if (carpetaPaciente != null)
            {
                List<string> carpetas = Directory.GetDirectories(carpetaPaciente).ToList();
                if (carpetas.Count == 1 && carpetas.First().ToUpper().Contains("BA"))
                {
                    return 1;
                }
                else if (carpetas.Count > 1)// && !carpetas.Any(c => c.ToUpper().Contains("BA"))) //Tiene carpetas de cada tto
                {
                    int numTtos = 0;
                    foreach (string carpeta in carpetas)
                    {
                        List<string> subCarpetas = Directory.GetDirectories(carpeta).ToList();
                        if (subCarpetas.Any(c => c.ToUpper().Contains("BA")))
                        {
                            numTtos++;
                        }
                    }
                    return numTtos;
                }
            }
            return 0;
        }
        public static string CarpetaBackup(string path)
        {
            List<string> carpetas = Directory.GetDirectories(path).ToList();
            if (carpetas.Count > 0)
            {
                if (carpetas.Any(c => c.ToUpper().Contains("BA")))
                {
                    return carpetas.Where(c => c.ToUpper().Contains("BA")).First();
                }
                else
                {
                    string carpetaEnTto = null;
                    DateTime fechaUltimaApl = DateTime.MinValue;
                    foreach (string carpetaParent in carpetas)
                    {
                        string carpeta = CarpetaBackup(carpetaParent);
                        if (carpeta != null)
                        {
                            var fileSystemInfo = new DirectoryInfo(carpeta).GetFileSystemInfos().Where(f => f.Name.Contains("BeamRecord")).OrderBy(f => f.LastWriteTime);
                            if (fileSystemInfo.Count() > 0 && (carpetaEnTto == null || fileSystemInfo.Last().LastWriteTime > fechaUltimaApl))
                            {
                                carpetaEnTto = carpeta;
                                fechaUltimaApl = fileSystemInfo.Last().LastWriteTime;
                            }
                        }
                    }

                    return carpetaEnTto;
                }
            }
            return null;
        }

        public static string CarpetaPaciente(Equipo equipo, string ID)
        {
            var carpetas = Directory.GetDirectories(equipo.RutaDicomRT).ToList();
            if (carpetas.Any(c => c.Contains(ID)))
            {
                return carpetas.Where(c => c.Contains(ID)).First();
            }
            else
            {
                return null;
            }
        }
        public static DateTime? FechaInicio(Equipo equipo, string ID)
        {
            string carpetaPaciente = MetodosDicomRT.CarpetaPaciente(equipo, ID);
            if (carpetaPaciente != null)
            {
                string carpetaBackup = MetodosDicomRT.CarpetaBackup(carpetaPaciente);
                if (carpetaBackup != null && Directory.GetFiles(carpetaBackup).Where(f => f.Contains("BeamRecord")).ToList().Count > 0)
                {
                    FileSystemInfo fileSystemInfo = new DirectoryInfo(carpetaBackup).GetFileSystemInfos().Where(f => f.Name.Contains("BeamRecord")).OrderBy(f => f.LastWriteTime).First();
                    return fileSystemInfo.LastWriteTime;
                }
            }
            return null;
        }

        public static int? ultimaFraccion(string carpetaPaciente)
        {
            if (carpetaPaciente != null)
            {
                List<string> carpetas = Directory.GetDirectories(carpetaPaciente).ToList();
                if (carpetas.Any(c => c.ToUpper().Contains("BA")))
                {
                    string carpetaBackup = CarpetaBackup(carpetaPaciente);
                    if (carpetaBackup != null && Directory.GetFiles(carpetaBackup).Where(f => f.Contains("BeamRecord")).ToList().Count > 0)
                    {
                        int numeroDeFracciones = new DirectoryInfo(carpetaBackup).GetFileSystemInfos().Where(f => f.Name.Contains("BeamRecord")).Select(f => f.LastWriteTime.Date).ToList().Distinct().Count();
                        if (new DirectoryInfo(carpetaPaciente).GetFileSystemInfos().Where(f => f.Name.Contains("BeamRecord")).Count() > 0)
                        {
                            numeroDeFracciones += new DirectoryInfo(carpetaPaciente).GetFileSystemInfos().Where(f => f.Name.Contains("BeamRecord")).Select(f => f.LastWriteTime.Date).ToList().Distinct().Count();
                        }
                        return numeroDeFracciones;
                    }
                }
                else if (carpetas.Count > 1)
                {
                    List<int> fracciones = new List<int>();
                    foreach (string carpeta in carpetas)
                    {
                        int? fx = ultimaFraccion(carpeta);
                        if (fx != null)
                        {
                            fracciones.Add((int)fx);
                        }
                    }
                    if (TratamientosSimultaneos(carpetaPaciente) > 1)
                    {
                        return fracciones.First();
                    }
                    else
                    {
                        return fracciones.Sum();
                    }
                }
            }
            return null;
        }

        public static int TratamientosSimultaneos(string carpetaPaciente)
        {
            if (carpetaPaciente != null)
            {
                List<string> carpetas = Directory.GetDirectories(carpetaPaciente).ToList();
                if (!carpetas.Any(c => c.ToUpper().Contains("BA")) && carpetas.Count > 1) //Tiene carpetas de cada tto
                {
                    List<DateTime> ultimaAplicacionFechas = new List<DateTime>();
                    foreach (string carpeta in carpetas)
                    {
                        string carpetaBackup = CarpetaBackup(carpeta);
                        if (carpetaBackup != null && Directory.GetFiles(carpetaBackup).Where(f => f.Contains("BeamRecord")).ToList().Count > 0)
                        {
                            DateTime ultimaApFecha = new DirectoryInfo(carpetaBackup).GetFileSystemInfos().Where(f => f.Name.Contains("BeamRecord")).OrderBy(f => f.LastWriteTime.Date).Last().LastWriteTime.Date;
                            ultimaAplicacionFechas.Add(ultimaApFecha);
                        }
                    }
                    DateTime ultimafecha = ultimaAplicacionFechas.Max(f => f);
                    return ultimaAplicacionFechas.Where(f => f.Equals(ultimafecha)).Count();
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }


        public static bool PlanPacienteSigueEnEquipoDia(Equipo equipo, double Dias, string carpetaPaciente, List<string> pacientesEstancados)
        {
            string aux = carpetaPaciente.Split(Path.DirectorySeparatorChar).Last();
            if (Char.IsLetter(aux.FirstOrDefault()) || (aux.Length < 4 || !aux.Substring(0, 4).Contains(" - ")))
            {
                string carpetaBackup = CarpetaBackup(carpetaPaciente);
                if (carpetaBackup != null && Directory.GetFiles(carpetaBackup).Where(f => f.Contains("BeamRecord")).ToList().Count > 0 && equipo.ID == EquipoPlan(carpetaPaciente))
                {
                    var archivos = new DirectoryInfo(carpetaBackup).GetFileSystemInfos().Where(f => f.Name.Contains("BeamRecord")).OrderBy(f => f.LastWriteTime);
                    FileSystemInfo fileSystemInfo = archivos.Last();
                    PlanPaciente planPaciente = ExtraerDeDCM(carpetaPaciente);
                    int? numeroDeFraccionesAplicadas = ultimaFraccion(carpetaPaciente);
                    DateTime ultimaFecha = fileSystemInfo.LastWriteTime;
                    if (numeroDeFraccionesAplicadas + Dias < planPaciente.NumeroFracciones && (DateTime.Today - ultimaFecha).Days < 7)
                    {
                        return true;
                    }
                    else if (Dias == 0 && (DateTime.Today - ultimaFecha).Days >= 7 && numeroDeFraccionesAplicadas != null && numeroDeFraccionesAplicadas < planPaciente.NumeroFracciones && planPaciente.EquipoID == equipo.ID)
                    {
                        if (numeroDeFraccionesAplicadas < 3)
                        {
                            planPaciente.BeamRecordOverride = BuscarOverride(carpetaBackup);
                        }
                        pacientesEstancados.Add(planPaciente.PacienteID + ";" + planPaciente.PacienteNombre + ";" + planPaciente.EquipoID + ";" + planPaciente.PlanID + ";" + ultimaFecha.ToShortDateString() + ";" + planPaciente.BeamRecordOverride.ToString());
                    }
                }
            }
            return false;
        }

        public static List<string> PacientesSiguenEnEquipoDia(Equipo equipo, double Dias)
        {
            List<string> pacientes = new List<string>();
            List<string> pacientesEstancados = new List<string>();
            //var carpetas = Directory.GetDirectories(@"\\Fisica0\dicom rt").ToList();
            var carpetas = CarpetasPacientes(equipo);

            foreach (string carpeta in carpetas)
            {
                if (carpeta.ToLower().Contains("marasco"))
                {

                }
                int numTtos = numeroDeTratamientos(carpeta);
                if (numTtos == 1)
                {
                    if (PlanPacienteSigueEnEquipoDia(equipo, Dias, carpeta, pacientesEstancados))
                    {
                        pacientes.Add(ExtraerDeDCM(carpeta).ToString());
                    }
                }
                else if (numTtos > 1)
                {
                    string[] subcarpetas = Directory.GetDirectories(carpeta);
                    foreach (string subcarpeta in subcarpetas)
                    {
                        if (PlanPacienteSigueEnEquipoDia(equipo, Dias, subcarpeta, pacientesEstancados))
                        {
                            pacientes.Add(ExtraerDeDCM(subcarpeta).ToString());
                        }
                    }
                }
                /*                string aux = carpeta.Split(Path.DirectorySeparatorChar).Last();
                                if (Char.IsLetter(aux.FirstOrDefault()))
                                {
                                    string carpetaBackup = CarpetaBackup(carpeta);
                                    if (carpetaBackup != null && Directory.GetFiles(carpetaBackup).Where(f => f.Contains("BeamRecord")).ToList().Count > 0)
                                    {
                                        var archivos = new DirectoryInfo(carpetaBackup).GetFileSystemInfos().Where(f => f.Name.Contains("BeamRecord")).OrderBy(f => f.LastWriteTime);
                                        FileSystemInfo fileSystemInfo = archivos.Last();
                                        PlanPaciente planPaciente = ExtraerDeDCM(carpeta);
                                        int? numeroDeFraccionesAplicadas = ultimaFraccion(carpeta);
                                        DateTime ultimaFecha = fileSystemInfo.LastWriteTime;
                                        if (numeroDeFraccionesAplicadas + Dias < planPaciente.NumeroFracciones && (DateTime.Today - ultimaFecha).Days < 7)
                                        {
                                            int tratamientosSimultaneos = TratamientosSimultaneos(carpeta);
                                            for (int i=0;i< tratamientosSimultaneos; i++)
                                            {
                                                pacientes.Add(planPaciente.ToString());
                                            }

                                        }
                                        else if (Dias == 0 && (DateTime.Today - ultimaFecha).Days >= 7 && numeroDeFraccionesAplicadas != null && numeroDeFraccionesAplicadas < planPaciente.NumeroFracciones && planPaciente.EquipoID == equipo.ID)
                                        {
                                            if (numeroDeFraccionesAplicadas < 3)
                                            {
                                                planPaciente.BeamRecordOverride = BuscarOverride(carpetaBackup);
                                            }
                                            pacientesEstancados.Add(planPaciente.PacienteID + ";" + planPaciente.PacienteNombre + ";" + planPaciente.EquipoID + ";" + planPaciente.PlanID + ";" + ultimaFecha.ToShortDateString() + ";" + planPaciente.BeamRecordOverride.ToString());
                                        }
                                    }
                                }*/
            }
            if (pacientesEstancados.Count > 0)
            {
                File.WriteAllLines(Equipo.pathArchivos + equipo.Nombre + "_estancados.txt", pacientesEstancados);
            }
            return pacientes;
        }

        public static string EquipoPlan(string carpetaPlan)
        {
            if (Directory.GetFiles(carpetaPlan).Where(f => f.Contains(".dcm") && !f.Contains("BeamRecord")).Count() > 0)
            {
                string dcmPath = Directory.GetFiles(carpetaPlan).Where(f => f.Contains(".dcm") && !f.Contains("BeamRecord")).First();
                var objeto = EvilDICOM.Core.DICOMObject.Read(dcmPath);
                return objeto.FindFirst("300A00B2").DData;
            }
            else
            {
                return "";
            }
        }
        public static PlanPaciente ExtraerDeDCM(string carpetaPaciente)
        {
            string _pacienteNombre = "";
            string _pacienteID = "";
            string _planID = "";
            int? _numFracciones = null;
            string _EquipoID = "";
            if (carpetaPaciente != null)
            {
                if (Directory.GetFiles(carpetaPaciente).Where(f => f.Contains(".dcm") && !f.Contains("BeamRecord")).Count() > 0)
                {
                    string dcmPath = Directory.GetFiles(carpetaPaciente).Where(f => f.Contains(".dcm") && !f.Contains("BeamRecord")).First();
                    var objeto = EvilDICOM.Core.DICOMObject.Read(dcmPath);
                    string nombreAux = objeto.FindFirst("00100010").DData.ToString();
                    string[] aux = nombreAux.Split('^');

                    _pacienteNombre = aux[0] + ", " + aux[1];
                    _pacienteID = objeto.FindFirst("00100020").DData.ToString();
                    _planID = objeto.FindFirst("300A0002").DData.ToString();
                    _numFracciones = objeto.FindFirst("300A0078").DData;
                    _EquipoID = objeto.FindFirst("300A00B2").DData;

                }
                /*else
                {
                    string[] subcarpetas = Directory.GetDirectories(carpetaPaciente);
                    if (Directory.GetFiles(subcarpetas.First()).Where(f => f.Contains(".dcm") && !f.Contains("BeamRecord")).Count() > 0)
                    {
                        string dcmPath = Directory.GetFiles(subcarpetas.First()).Where(f => f.Contains(".dcm") && !f.Contains("BeamRecord")).First();
                        var objeto = EvilDICOM.Core.DICOMObject.Read(dcmPath);
                        string nombreAux = objeto.FindFirst("00100010").DData.ToString();
                        string[] aux = nombreAux.Split('^');

                        _pacienteNombre = aux[0] + ", " + aux[1];
                        _pacienteID = objeto.FindFirst("00100020").DData.ToString();
                        _planID = objeto.FindFirst("300A0002").DData.ToString();
                        _numFracciones = objeto.FindFirst("300A0078").DData;
                        _EquipoID = objeto.FindFirst("300A00B2").DData;
                    }
                    foreach (string subcarpeta in subcarpetas.Skip(1))
                    {
                        if (Directory.GetFiles(subcarpeta).Where(f => f.Contains(".dcm") && !f.Contains("BeamRecord")).Count() > 0)
                        {
                            string dcmPath = Directory.GetFiles(subcarpeta).Where(f => f.Contains(".dcm") && !f.Contains("BeamRecord")).First();
                            var objeto = EvilDICOM.Core.DICOMObject.Read(dcmPath);
                            if (objeto.FindFirst("300A0078").DData != _numFracciones)
                            {
                                _numFracciones += objeto.FindFirst("300A0078").DData;
                            }
                        }
                    }
                }*/
            }
            return new PlanPaciente(_pacienteID, _pacienteNombre, _planID, _numFracciones, _EquipoID);
        }

        public static bool BuscarOverride(string carpetaPaciente)
        {
            if (carpetaPaciente != null)
            {
                //if (Directory.GetFiles(carpetaPaciente).Where(f => f.Contains(".dcm") && f.Contains("BeamRecord")).Count() > 0)
                if (Directory.GetFiles(carpetaPaciente).Where(f => f.Contains("BeamRecord")).Count() > 0)
                {
                    List<string> BeamRecords = Directory.GetFiles(carpetaPaciente).Where(s => s.Contains("BeamRecord")).ToList();
                    foreach (string BeamRecord in BeamRecords)
                    {
                        var objeto = EvilDICOM.Core.DICOMObject.Read(BeamRecord);
                        if (objeto.FindAll("30080062").Count > 0 && objeto.FindFirst("30080062").DData.ToString().Contains("TreatmentMachine"))
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }


        public static List<string> CarpetasPacientes(Equipo equipo)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(equipo.RutaDicomRT);
            List<string> carpetas = directoryInfo.GetDirectories().Where(d => (DateTime.Today - d.LastWriteTime).Days < 120).Select(d => d.FullName).ToList();
            List<string> carpetasFiltradas = new List<string>();
            foreach (string carpeta in carpetas)
            {
                string aux = carpeta.Split(Path.DirectorySeparatorChar).Last();
                if (Char.IsLetter(aux.FirstOrDefault()))
                {
                    carpetasFiltradas.Add(carpeta);
                }
            }
            return carpetasFiltradas;


        }
    }
}

