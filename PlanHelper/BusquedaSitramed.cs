// Decompiled with JetBrains decompiler
// Type: PlanHelper.BusquedaSitramed
// Assembly: PlanHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1B579B3F-36E4-4058-869C-F42E71A51D15
// Assembly location: C:\Recuperacion PlanHelper\PlanHelper_copia ejecutable\PlanHelper.exe

using OpenTwebstLib;
using System;
using System.Collections.Generic;
using System.IO;
//using System.Runtime.InteropServices;

namespace PlanHelper
{
    public class BusquedaSitramed
    {
        [STAThread]
        public static void Correr()
        {
            // ISSUE: variable of a compiler-generated typeº
            ICore core = new core();
            IBrowser browser = core.StartBrowser("http://10.0.0.39/sitramed/Default.asp");

            browser.nativeBrowser.Visible = false;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            browser.FindElement("input text", "name=txtUsuario").InputText("PDABERBUJ");
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            browser.FindElement("input password", "name=txtPassword").InputText("3060");
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            browser.FindElement("input button", "name=B3").Click();
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            browser.FindElement("p", "uiname=Agenda de Turnos").Click();
            List<string> stringList1 = new List<string>();
            stringList1.Add("Equipo 1");
            stringList1.Add("Equipo 2");
            stringList1.Add("Equipo 3");
            stringList1.Add("Equipo 4");
            List<string> stringList2 = new List<string>();
            DateTime dia = ConsultasDB.AddBusinessDays(DateTime.Today, 1.0);
            stringList2.Add("Inicios día: " + dia.ToString("dd/MM/yyyy"));
            foreach (string equipo in stringList1)
                stringList2.AddRange((IEnumerable<string>)BusquedaSitramed.PlacasEquipoDia(equipo, dia, browser));
            // ISSUE: reference to a compiler-generated method
            browser.Close();
            File.WriteAllLines(Equipo.pathArchivos + "\\placas.txt", stringList2.ToArray());
        }

        public static List<string> PlacasEquipoDia(string equipo, DateTime dia, IBrowser browser)
        {
            string bstrText = dia.ToString("dd/MM/yyyy").Replace('-', '/');
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            browser.FindElement("td", "id=td2_1").Click();
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            browser.FindElement("select", "name=cboSucursal").Select((object)"MEVATERAPIA");
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            browser.FindElement("select", "name=cboMedico").Select((object)equipo);
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            browser.FindElement("input text", "name=txtFAgenda").InputText(bstrText);
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            browser.FindElement("input button", "uiname=Buscar").Click();
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            IElement element = browser.FindElement("TABLE", "id=daydata");
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            IElement childElement = element.FindChildElement("TBODY", "");
            string innerHtml = childElement.nativeElement.innerHTML;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            IElementList childrenElements1 = childElement.FindChildrenElements("tr", "");
            int length = childrenElements1.length;
            List<string> stringList = new List<string>();
            stringList.Add(equipo);
            for (int nIndex = 0; nIndex < length; ++nIndex)
            {
                if (childrenElements1[nIndex].nativeElement.innerHTML.Contains("PLACA VERIF"))
                {
                    // ISSUE: reference to a compiler-generated method
                    // ISSUE: variable of a compiler-generated type
                    IElementList childrenElements2 = childrenElements1[nIndex].FindChildrenElements("td", "");
                    stringList.Add(BusquedaSitramed.horaNombre(childrenElements2[1].nativeElement.innerText));
                }
            }
            if (stringList.Count == 1)
                stringList.Clear();
            return stringList;
        }

        public static string horaNombre(string linea)
        {
            linea = linea.Replace("  ", "-");
            string[] strArray = linea.Split('-');
            return strArray[0].Trim() + " - " + strArray[2].Trim();
        }
    }
}
