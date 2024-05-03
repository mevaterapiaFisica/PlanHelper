using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanHelper
{
    public class Parametro
    {
        public string StatusInicial { get; set; }
        public string Modalidad { get; set; }
        public int? Dias { get; set; }
        public int Margen { get; set; }
        public bool ValeParaTodasLasFracciones { get; set; }
        public int Fracciones { get; set; }

        public Parametro(string _status, string _modalidad, int? _dias, int _margen,    bool _valeParaTodasLasFracciones, int _fracciones)
        {
            StatusInicial = _status;
            Modalidad = _modalidad;
            Dias = _dias;
            Margen = _margen;
            ValeParaTodasLasFracciones = _valeParaTodasLasFracciones;
            Fracciones = _fracciones;
        }
        public override string ToString()
        {
            if (Dias != null)
            {
                return StatusInicial + ";" + Modalidad.ToString() + "; Dias: " +  Dias.ToString() + "; Margen: " + Margen.ToString() + ";" + ValeParaTodasLasFracciones.ToString() + ";" + Fracciones.ToString();
            }
            else
            {
                return StatusInicial + ";" + Modalidad.ToString() + ";" + "null" + ";" + "null" + ";" + ValeParaTodasLasFracciones.ToString() + ";" + Fracciones.ToString();
            }
        }

        public static Parametro FromString(string parametroString)
        {
            string[] aux = parametroString.Split(';');
            if (aux[2] != "null")
            {
                return new Parametro(aux[0], aux[1], Convert.ToInt32(aux[2].Replace("Dias: ","")),Convert.ToInt32(aux[3].Replace("Margen: ", "")), Convert.ToBoolean(aux[4]), Convert.ToInt32(aux[5]));
            }
            else
            {
                return new Parametro(aux[0], aux[1], null, Convert.ToInt32(aux[3]), Convert.ToBoolean(aux[4]), Convert.ToInt32(aux[5]));
            }

        }
    }
}
