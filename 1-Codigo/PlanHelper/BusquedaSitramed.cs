// Decompiled with JetBrains decompiler
// Type: PlanHelper.BusquedaSitramed
// Assembly: PlanHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1B579B3F-36E4-4058-869C-F42E71A51D15
// Assembly location: C:\Recuperacion PlanHelper\PlanHelper_copia ejecutable\PlanHelper.exe

using OpenTwebstLib;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Runtime.InteropServices;

namespace PlanHelper
{
    public class BusquedaSitramed
    {
        [STAThread]

        public static void PruebaChrome()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            //chromeOptions.AddArgument("--headless");
            chromeOptions.AddArguments("window-size=1920,1080");
            var driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("https://mevaterapia.lambdaclass.com/session/new?request_path=%2F");
            driver.FindElement(By.Id("user_email")).SendKeys("pablo.aberbuj@mevaterapia.com.ar");
            driver.FindElement(By.Id("user_password")).SendKeys("123qweQW");
            driver.FindElement(By.CssSelector(".is-flex > .button:nth-child(1)")).Click();
            string[] Equipos = new string[] { "Equipo 4" };//{ "Equipo 1", "Equipo 2", "Equipo 3", "Equipo 4" };
            List<DateTime> dias = new List<DateTime>();
            dias.Add(DateTime.Today);
            for (int i = 4; i < 5; i++)
            //for (int i = 1; i < 5; i++)
            {
                dias.Add(ConsultasDB.AddBusinessDays(DateTime.Today, i));
            }
            List<OcupacionEquipo> ocupacionEquipos = new List<OcupacionEquipo>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (string Equipo in Equipos)
            {
                foreach (DateTime dia in dias)
                {
                    ocupacionEquipos.Add(new OcupacionEquipo(Equipo, dia, citasDiaEquipo(dia, Equipo, driver)));
                }
            }

            driver.Close();
            /*browser.getAllWindowHandles().then(function(handles) {
                browser.driver.switchTo().window(handles[1]);
                browser.driver.close();
                browser.driver.switchTo().window(handles[0]);
        }*/

            var tiempo = sw.Elapsed;
        }

        public static List<OcupacionEquipo> BuscarOcupacionEquipos(List<Equipo> equipos)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            chromeOptions.AddArguments("window-size=1920,1080");
            var driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("https://mevaterapia.lambdaclass.com/session/new?request_path=%2F");
            driver.FindElement(By.Id("user_email")).SendKeys("pablo.aberbuj@mevaterapia.com.ar");
            driver.FindElement(By.Id("user_password")).SendKeys("123qweQW");
            driver.FindElement(By.CssSelector(".is-flex > .button:nth-child(1)")).Click();
            List<OcupacionEquipo> ocupacionEquipos = new List<OcupacionEquipo>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (Equipo equipo in equipos)
            {
                int? maximoDias = 0;
                int? margen = 0;
                if (equipo.Parametros.OrderBy(p => p.Dias).Last().Dias > maximoDias)
                {
                    maximoDias = equipo.Parametros.OrderBy(p => p.Dias).Last().Dias;
                }
                if (equipo.Parametros.OrderBy(p => p.Dias).Last().Margen > margen)
                {
                    margen = equipo.Parametros.OrderBy(p => p.Dias).Last().Margen;
                }
                for (int i = 0; i < ((int)maximoDias + (int)margen); i++)
                {
                    DateTime dia = ConsultasDB.AddBusinessDays(DateTime.Today, i);
                    ocupacionEquipos.Add(new OcupacionEquipo(equipo.Nombre, dia, citasDiaEquipo(dia, equipo.Nombre, driver)));
                }
            }
            driver.Close();
            driver.Dispose();
            return ocupacionEquipos;
        }

        public static List<TurnoSitra> citasDiaEquipo(DateTime dia, string Equipo, IWebDriver driver)
        {
            System.Threading.Thread.Sleep(2000);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            List<TurnoSitra> citas = new List<TurnoSitra>();
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
            driver.Navigate().GoToUrl("https://mevaterapia.lambdaclass.com/reception/appointments/machine");

            SeleccionarEquipo(Equipo, driver, wait);
            System.Threading.Thread.Sleep(500);

            SeleccionarFecha(dia, driver, wait, true);
            System.Threading.Thread.Sleep(500);

            CHequearFecha(driver, dia, wait);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("machineDrag")));
            var elemento = driver.FindElement(By.Id("machineDrag"));
            List<IWebElement> lstTrElem = new List<IWebElement>(elemento.FindElements(By.TagName("tr")));
            foreach (var elemTr in lstTrElem)
            {
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 4)
                {
                    string strRowData = "";
                    foreach (var elemTd in lstTdElem)
                    {
                        if (elemTd == null || elemTd.Text == "")
                        {
                            strRowData = strRowData + " ;";
                        }
                        else
                        {
                            strRowData = strRowData + elemTd.Text + ";";
                        }
                    }
                    TurnoSitra turnoSitra = new TurnoSitra(strRowData);
                    if (turnoSitra.Paciente != null)
                    {
                        citas.Add(turnoSitra);
                    }

                }
            }
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
            return citas;

        }

        public static void SeleccionarFecha(DateTime fecha, IWebDriver driver, WebDriverWait wait, bool esPrimeraVez)
        {
            var DTP = driver.FindElement(By.Id("search_date"));
            wait.Until(ExpectedConditions.ElementToBeClickable(DTP));
            var DTPmain = driver.FindElement(By.ClassName("datepicker-main"));
            driver.FindElement(By.Id("search_date")).Click();
            string dia = fecha.ToString("dd");
            if (dia[0] == '0')
            {
                dia = dia.Remove(0, 1);
            }
            if (esPrimeraVez && fecha.Month != DateTime.Today.Month)
            {
                var next = driver.FindElement(By.CssSelector(".next-btn"));
                wait.Until(ExpectedConditions.ElementToBeClickable(next));
                next.Click();
            }
            foreach (IWebElement ele in DTPmain.FindElements(By.ClassName("datepicker-cell"))) // use foreach iterate each cell.
            {
                if (!ele.GetAttribute("class").Contains("prev"))
                {
                    string date = ele.GetAttribute("textContent"); // get the text of the element.

                    if (date == dia) // check if the date is 20
                    {
                        ele.Click(); // if date is 20, select it.
                        break;
                    }
                }
            }
        }

        public static void SeleccionarEquipo(string Equipo, IWebDriver driver, WebDriverWait wait)
        {
            var dropdown = driver.FindElement(By.Id("search_machine_id"));
            var selectElement = new SelectElement(dropdown);
            wait.Until(ExpectedConditions.ElementToBeClickable(dropdown));
            selectElement.SelectByText(Equipo);
        }

        public static void CHequearFecha(IWebDriver driver, DateTime fecha, WebDriverWait wait)
        {
            string fechaS = fecha.ToString("yyyy-MM-dd");
            var subs = driver.FindElements(By.ClassName("subtitle"));
            foreach (var sub in subs)
            {
                if (sub.Text.Contains("Turnos "))
                {
                    var texto = sub.Text;
                    while (!sub.Text.Contains(fechaS))
                    {
                        SeleccionarFecha(fecha, driver, wait, false);
                        Thread.Sleep(1500);
                    }
                }
            }
        }

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
            browser.FindElement("input password", "name=txtPassword").InputText("1213");
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
            browser.FindElement("select", "name=cboSucursal").Select((object)"MEVA-Central");
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
