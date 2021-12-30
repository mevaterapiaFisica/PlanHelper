using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanHelper
{
    public static class MetodosAuxiliares
    {
        public static void EscribirSiEstaDisponible(string path, string[] contenido)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        stream.Close();
                        File.WriteAllLines(path, contenido);
                    }
                }
                catch (IOException)
                {
                    System.Threading.Thread.Sleep(1000);
                    EscribirSiEstaDisponible(path, contenido);
                }
            }
            else
            {
                File.WriteAllLines(path, contenido);
            }
        }
    }
}
