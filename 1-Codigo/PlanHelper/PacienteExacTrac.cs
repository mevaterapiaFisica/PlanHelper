using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvilDICOM.Core;

namespace PlanHelper
{
    public class PacienteExacTrac
    {
        public static string pathEquipo1 = @"\\10.0.0.38\fileRef";
        public static string pathEquipo4 = @"\\10.0.0.38\fileRef";

        public string ID { get; set; }
        public string Nombre { get; set; }
        public List<string> Planes { get; set; }
        //public int CantidadEstudios { get; set; }
        public bool hayCT { get; set; }
        public bool HayStructureSet { get; set; }

        public PacienteExacTrac(string carpeta)
        {
            Planes = new List<string>();
            List<string> subsubcarpetas = new List<string>();
            foreach (string subcarpeta in Directory.GetDirectories(carpeta))
            {
                subsubcarpetas.AddRange(Directory.GetDirectories(subcarpeta).ToList());
            }
            foreach (string subsubcarpeta in subsubcarpetas)
            {
                string[] lista = Directory.GetFiles(subsubcarpeta, "*.dcm");
                foreach (string archivo in lista)
                {
                    if (Path.GetFileName(archivo).Contains("RTSTRUC"))
                    {
                        HayStructureSet = true;
                    }
                    else
                    {
                        var objeto = DICOMObject.Read(archivo);
                        string SOPClassUID = ObtenerSOPClassUID(objeto);
                        if (SOPClassUID == "CTImage")
                        {
                            hayCT = true;
                            break;
                        }
                        else if (SOPClassUID == "RTPlan")
                        {
                            Planes.Add(objeto.FindFirst("300A0002").DData.ToString());
                            Nombre = objeto.FindFirst("00100010").DData.ToString();
                            ID = objeto.FindFirst("00100020").DData.ToString();
                        }
                        else if (SOPClassUID == "RTStructureSet")
                        {
                            HayStructureSet = true;
                        }
                    }
                    
                }
            }
        }

        public static List<PacienteExacTrac> BuscarPacientes(string path)
        {
            string[] carpetasPacientes = Directory.GetDirectories(path);
            List<PacienteExacTrac> pacientes = new List<PacienteExacTrac>();
            foreach (string carpeta in carpetasPacientes)
            {
                pacientes.Add(new PacienteExacTrac(carpeta));
            }
            return pacientes;
        }

        public static string ObtenerSOPClassUID(DICOMObject dcm)
        {
            var SOPClassUID = dcm.FindFirst("00080016").DData;
            if (SOPClassUID == "1.2.840.10008.5.1.4.1.1.2")
            {
                return "CTImage";
            }
            else if (SOPClassUID == "1.2.840.10008.5.1.4.1.1.481.5")
            {
                return "RTPlan";
            }
            else if (SOPClassUID == "1.2.840.10008.5.1.4.1.1.481.3")
            {
                return "RTStructureSet";
            }
            else
            {
                return "Desconocido";
            }
        }
    }
}
