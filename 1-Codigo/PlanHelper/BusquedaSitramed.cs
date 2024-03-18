// Decompiled with JetBrains decompiler
// Type: PlanHelper.BusquedaSitramed
// Assembly: PlanHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1B579B3F-36E4-4058-869C-F42E71A51D15
// Assembly location: C:\Recuperacion PlanHelper\PlanHelper_copia ejecutable\PlanHelper.exe

using OpenTwebstLib;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
//using System.Runtime.InteropServices;

namespace PlanHelper
{
    public class BusquedaSitramed
    {
        [STAThread]

        /*public static void PruebaChrome()
        {
            // instantiate a driver instance to control
            // Chrome in headless mode
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("--headless=new"); // comment out for testing
            var driver = new ChromeDriver(chromeOptions);

            // open the target page in Chrome
            driver.Navigate().GoToUrl("https://mevaterapia.lambdaclass.com/session/new?request_path=%2F");
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.FindElement(By.Id("user_email")).SendKeys("pablo.aberbuj@mevaterapia.com.ar");
            driver.FindElement(By.Id("user_password")).SendKeys("123qweQW");
            driver.FindElement(By.CssSelector(".is-flex > .button:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector(".dropdown-container:nth-child(2) > .menu-label")).Click();
            driver.FindElement(By.CssSelector(".open .sublist:nth-child(4) > li:nth-child(1) > a")).Click();


            string[] Equipos = new string[] { "Equipo 1", "Equipo 2", "Equipo 3", "Equipo 4" };
            DateTime[] dias = new DateTime[] { DateTime.Today, DateTime.Today.AddDays(3), DateTime.Today.AddDays(4), DateTime.Today.AddDays(5) };
            List<List<string>> superLista = new List<List<string>>();
            List<string> lista = new List<string>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (string Equipo in Equipos)
            {
                foreach (DateTime dia in dias)
                {
                    lista.Add(citasDiaEquipo(dia, Equipo, driver));
                }
            }
            /*Thread thread = new Thread(obj => citasDiaEquipo(dias[0], Equipos[0], driver,1));
            Thread thread2 = new Thread(obj => citasDiaEquipo(dias[1], Equipos[0], driver,2));
            Thread thread3 = new Thread(obj => citasDiaEquipo(dias[0], Equipos[1], driver,3));
            Thread thread4 = new Thread(obj => citasDiaEquipo(dias[1], Equipos[1], driver,4));

            thread.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            var tiempo = sw.Elapsed;

            //var citasEq3 = citasDiaEquipo(DateTime.Today, "Equipo 3", driver);
            driver.Close();
            //int cantidad = citasEq3.Count;
        }*/

       /* public static string citasDiaEquipo(DateTime dia, string Equipo, ChromeDriver driver)
        {
            //System.Threading.Thread.Sleep(600);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            List<string> citas = new List<string>();
            // driver.Navigate().GoToUrl("https://mevaterapia.lambdaclass.com/reception/appointments/machine");
            //driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            //((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            //driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.SwitchTo().Window(driver.WindowHandles[tab]);
            //driver.Navigate().GoToUrl("https://mevaterapia.lambdaclass.com/reception/appointments/machine");

            SeleccionarFecha(dia, driver, wait);
            System.Threading.Thread.Sleep(2000);

            SeleccionarEquipo(Equipo, driver, wait);
            System.Threading.Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("machineDrag")));
            var elemento = driver.FindElement(By.Id("machineDrag"));
            driver.FindElement(By.)
           /* List<IWebElement> lstTrElem = new List<IWebElement>(elemento.FindElements(By.TagName("tr")));
            foreach (var elemTr in lstTrElem)
            {
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 4)
                {
                    string strRowData = "";
                    foreach (var elemTd in lstTdElem)
                    {
                        strRowData = strRowData + elemTd.Text + ";";
                    }
                    citas.Add(strRowData);
                }
            }

            var cells = elemento.FindElements(By.XPath("//tbody/tr/td"));

            // Iterate through each cell
            string textoTabla = "";
            foreach (WebElement cell in cells)
            {
                textoTabla += cell.Text + cell.TagName;
                // Process the cell data as needed
                
            }

            return textoTabla;
            /*foreach (var fila in tbody)
            {
                //var celdas = fila.FindElements(By.TagName("tr"));
                var horaInicio = fila.FindElement(By.PartialLinkText("/reception/appointments/machine/")).Text;
                var nombre = fila.FindElement(By.PartialLinkText("/reception/appointments/machine/")).Text;
            }
            //return citas;
            string path = @"C:\" + Equipo + "_" + dia.ToString("dd_MMM_yyyy") + ".txt";
            File.WriteAllLines(path, citas.ToArray());
        }*/

       /* public static void SeleccionarFecha(DateTime fecha, ChromeDriver driver, WebDriverWait wait)
        {
            var DTP = driver.FindElement(By.Id("search_date"));
            wait.Until(ExpectedConditions.ElementToBeClickable(DTP));
            DTP.Clear();
            DTP.SendKeys(fecha.ToString("yyyy-MM-dd"));
            DTP.SendKeys(Keys.Enter);
        }*/

        /*public static void SeleccionarEquipo(string Equipo, ChromeDriver driver, WebDriverWait wait)
        {
            var dropdown = driver.FindElement(By.Id("search_machine_id"));
            var selectElement = new SelectElement(dropdown);
            wait.Until(ExpectedConditions.ElementToBeClickable(dropdown));
            selectElement.SelectByText(Equipo);
        }*/
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
