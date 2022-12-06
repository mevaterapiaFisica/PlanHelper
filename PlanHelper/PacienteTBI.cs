// Decompiled with JetBrains decompiler
// Type: PlanHelper.PacienteTBI
// Assembly: PlanHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1B579B3F-36E4-4058-869C-F42E71A51D15
// Assembly location: C:\Recuperacion PlanHelper\PlanHelper_copia ejecutable\PlanHelper.exe

using AriaQ;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PlanHelper
{
  public class PacienteTBI
  {
    public static string pathPacientesTBI = Equipo.pathArchivos + "\\pacientesTBI.txt";

    public string ID { get; set; }
    public string Apellido { get; set; }
    public string Nombre { get; set; }
    public string Curso { get; set; }
    public string PlanAnt { get; set; }
    public string PlanPost { get; set; }
    public Equipo Equipo { get; set; }
    public DateTime FechaInicio { get; set; }
    public int NumeroFracciones { get; set; }
    public int FraccionesPorDia { get; set; }
    public bool LlevaPb { get; set; }
    public bool CTIngresada { get; set; }
    public bool PlanesCreados { get; set; }
    public bool PlanesAprobados { get; set; }
    public bool TratamientoAprobado { get; set; }
    public bool PbHechos { get; set; }
    public bool CIHecho { get; set; }
    public bool ArchivosEnEquipo { get; set; }

    public PacienteTBI(
      string _ID,
      string _Apellido,
      string _Nombre,
      string _equipo,
      DateTime _FechaInicio,
      int _numFx,
      int _FxPorDia = 1)
    {
      this.ID = _ID;
      this.Apellido = _Apellido;
      this.Nombre = _Nombre;
      this.Curso = "";
      this.PlanAnt = "";
      this.PlanPost = "";
      this.Equipo = Equipo.FromStringNombre(_equipo);
      this.FechaInicio = _FechaInicio;
      this.NumeroFracciones = _numFx;
      this.FraccionesPorDia = _FxPorDia;
    }

    public PacienteTBI(string String)
    {
      string[] strArray = String.Split(';');
      this.ID = strArray[0];
      this.Apellido = strArray[1];
      this.Nombre = strArray[2];
      this.Curso = strArray[3];
      this.PlanAnt = strArray[4];
      this.PlanPost = strArray[5];
      this.Equipo = Equipo.FromStringNombre(strArray[6]);
      this.FechaInicio = DateTime.ParseExact(strArray[7], "dd-MM-yyyy", (IFormatProvider) CultureInfo.InvariantCulture);
      this.NumeroFracciones = Convert.ToInt32(strArray[8]);
      this.FraccionesPorDia = Convert.ToInt32(strArray[9]);
      this.LlevaPb = Convert.ToBoolean(strArray[10]);
      this.CTIngresada = Convert.ToBoolean(strArray[11]);
      this.PlanesCreados = Convert.ToBoolean(strArray[12]);
      this.PlanesAprobados = Convert.ToBoolean(strArray[13]);
      this.TratamientoAprobado = Convert.ToBoolean(strArray[14]);
      this.PbHechos = Convert.ToBoolean(strArray[15]);
      this.CIHecho = Convert.ToBoolean(strArray[16]);
      this.ArchivosEnEquipo = Convert.ToBoolean(strArray[17]);
    }

    public PacienteTBI(PlanSetup plan)
    {
      Patient patient = plan.Course.Patient;
      PlanSetup planSetup1 = plan.Course.PlanSetups.FirstOrDefault<PlanSetup>((Func<PlanSetup, bool>) (p => p.PlanSetupId.ToLower().Contains("tbi") && p.PlanSetupId.ToLower().Contains("ant")));
      PlanSetup planSetup2 = plan.Course.PlanSetups.FirstOrDefault<PlanSetup>((Func<PlanSetup, bool>) (p => p.PlanSetupId.ToLower().Contains("tbi") && p.PlanSetupId.ToLower().Contains("pos")));
      this.ID = patient.PatientId;
      this.Apellido = patient.LastName;
      this.Nombre = patient.FirstName;
      this.Curso = plan.Course.CourseId;
      this.PlanAnt = planSetup1.PlanSetupId;
      this.PlanPost = planSetup2.PlanSetupId;
      this.Equipo = Equipo.FromString(plan.Radiations.First<Radiation>().RadiationDevice.Machine.MachineId);
      if (plan.RTPlans.First<RTPlan>().NoFractions.HasValue)
        this.NumeroFracciones = plan.RTPlans.First<RTPlan>().NoFractions.Value;
      if (plan.RTPlans.First<RTPlan>().PrescribedDose.HasValue)
      {
        double? nullable1 = plan.RTPlans.First<RTPlan>().PrescribedDose;
        double num1 = 2.0;
        double? nullable2 = nullable1.HasValue ? new double?(nullable1.GetValueOrDefault() * num1) : new double?();
        double numeroFracciones = (double) this.NumeroFracciones;
        double? nullable3;
        if (!nullable2.HasValue)
        {
          nullable1 = new double?();
          nullable3 = nullable1;
        }
        else
          nullable3 = new double?(nullable2.GetValueOrDefault() * numeroFracciones);
        double? nullable4 = nullable3;
        double num2 = 9.0;
        this.LlevaPb = nullable4.GetValueOrDefault() > num2 & nullable4.HasValue;
      }
      if (!string.IsNullOrEmpty(this.PlanAnt))
      {
        this.CTIngresada = true;
        this.PlanesCreados = true;
      }
      if (planSetup1.Status == "PlanApproval" && planSetup2.Status == "PlanApproval")
        this.PlanesAprobados = true;
      if (!(planSetup1.Status == "TreatApproval") || !(planSetup2.Status == "TreatApproval"))
        return;
      this.PlanesAprobados = true;
      this.TratamientoAprobado = true;
    }

    public void Actualizar(PlanSetup plan)
    {
      PlanSetup planSetup1 = plan.Course.PlanSetups.FirstOrDefault<PlanSetup>((Func<PlanSetup, bool>) (p => p.PlanSetupId.ToLower().Contains("tbi") && p.PlanSetupId.ToLower().Contains("ant")));
      PlanSetup planSetup2 = plan.Course.PlanSetups.FirstOrDefault<PlanSetup>((Func<PlanSetup, bool>) (p => p.PlanSetupId.ToLower().Contains("tbi") && p.PlanSetupId.ToLower().Contains("pos")));
      this.Curso = plan.Course.CourseId;
      this.PlanAnt = planSetup1.PlanSetupId;
      this.PlanPost = planSetup2.PlanSetupId;
      double? prescribedDose = plan.RTPlans.First<RTPlan>().PrescribedDose;
      this.Nombre = plan.Course.Patient.FirstName;
      if (plan.RTPlans.First<RTPlan>().NoFractions.HasValue && this.NumeroFracciones != plan.RTPlans.First<RTPlan>().NoFractions.Value)
        this.NumeroFracciones = 1000;
      if (plan.RTPlans.First<RTPlan>().PrescribedDose.HasValue)
      {
        double? nullable1 = plan.RTPlans.First<RTPlan>().PrescribedDose;
        double num1 = 2.0;
        double? nullable2 = nullable1.HasValue ? new double?(nullable1.GetValueOrDefault() * num1) : new double?();
        double numeroFracciones = (double) this.NumeroFracciones;
        double? nullable3;
        if (!nullable2.HasValue)
        {
          nullable1 = new double?();
          nullable3 = nullable1;
        }
        else
          nullable3 = new double?(nullable2.GetValueOrDefault() * numeroFracciones);
        double? nullable4 = nullable3;
        double num2 = 9.0;
        this.LlevaPb = nullable4.GetValueOrDefault() > num2 & nullable4.HasValue;
      }
      if (!this.Equipo.Equals((object) Equipo.FromString(plan.Radiations.First<Radiation>().RadiationDevice.Machine.MachineId)))
        this.Equipo = Equipo.Discrepancia();
      if (!string.IsNullOrEmpty(this.PlanAnt))
      {
        this.CTIngresada = true;
        this.PlanesCreados = true;
      }
      if (planSetup1.Status == "PlanApproval" && planSetup2.Status == "PlanApproval")
        this.PlanesAprobados = true;
      if (!(planSetup1.Status == "TreatApproval") || !(planSetup2.Status == "TreatApproval"))
        return;
      this.PlanesAprobados = true;
      this.TratamientoAprobado = true;
    }

    public override string ToString() => this.ID + ";" + this.Apellido + ";" + this.Nombre + ";" + this.Curso + ";" + this.PlanAnt + ";" + this.PlanPost + ";" + this.Equipo.Nombre + ";" + this.FechaInicio.ToString("dd-MM-yyyy") + ";" + this.NumeroFracciones.ToString() + ";" + this.FraccionesPorDia.ToString() + ";" + this.LlevaPb.ToString() + ";" + this.CTIngresada.ToString() + ";" + this.PlanesCreados.ToString() + ";" + this.PlanesAprobados.ToString() + ";" + this.TratamientoAprobado.ToString() + ";" + this.PbHechos.ToString() + ";" + this.CIHecho.ToString() + ";" + this.ArchivosEnEquipo.ToString();

    public bool Finalizo() => ConsultasDB.AddBusinessDaysSinFeriados(this.FechaInicio, (double) (this.NumeroFracciones / this.FraccionesPorDia)) < DateTime.Today;

    public static List<PacienteTBI> eliminarFinalizados(List<PacienteTBI> pacientes)
    {
      List<PacienteTBI> pacienteTbiList = new List<PacienteTBI>();
      foreach (PacienteTBI paciente in pacientes)
      {
        if (!paciente.Finalizo())
          pacienteTbiList.Add(paciente);
      }
      return pacienteTbiList;
    }

    public static List<PacienteTBI> LeerArchivo()
    {
      List<PacienteTBI> pacienteTbiList = new List<PacienteTBI>();
      if (File.Exists(PacienteTBI.pathPacientesTBI))
      {
        foreach (string String in ((IEnumerable<string>) File.ReadAllLines(PacienteTBI.pathPacientesTBI)).Skip<string>(1))
          pacienteTbiList.Add(new PacienteTBI(String));
      }
      return pacienteTbiList;
    }

    public static void EscribirArchivo(List<PacienteTBI> pacientesTBI)
    {
      List<string> stringList = new List<string>();
      stringList.Add("HC;Apellido;Nombre;Curso;PlanAnt;PlanPost;Eq;Inicio;Nº Fx;Fx por día;Lleva Pb;TAC;Planes creados;Plan;Treatment;Pb listos;CheckList;Archivos");
      stringList.AddRange(pacientesTBI.OrderBy<PacienteTBI, string>((Func<PacienteTBI, string>) (p => p.Apellido)).Select<PacienteTBI, string>((Func<PacienteTBI, string>) (p => p.ToString())));
      File.WriteAllLines(PacienteTBI.pathPacientesTBI, stringList.ToArray());
    }
  }
}
