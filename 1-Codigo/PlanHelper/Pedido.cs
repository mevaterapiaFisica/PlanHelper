using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanHelper
{
    public class Pedido
    {

        public static string pathOpciones = @"\\ariamevadb-svr\va_data$\PlanHelper\Archivos\pedidosOpciones.txt";
        public static string pathPedidos = @"\\ariamevadb-svr\va_data$\PlanHelper\Archivos\pedidos.txt";
        public static string pathPedidosCompletados = @"\\ariamevadb-svr\va_data$\PlanHelper\Archivos\pedidosCompletados.txt";

        public string Paciente { get; set; }
        public string Tecnica { get; set; }
        public string Tarea { get; set; }
        public string Equipo { get; set; }
        public DateTime FechaLimite { get; set; }
        public string MedicoResponsable { get; set; }
        public string Motivo { get; set; }
        public string Solicita { get; set; }
        public string Responsable { get; set; }
        public string Comentario { get; set; }
        public bool EsCambioDeEstado { get; set; }

        public Pedido(string linea)
        {
            string[] elementos = linea.Split(';');
            Paciente = elementos[0];
            Tecnica = elementos[1];
            Tarea = elementos[2];
            Equipo = elementos[3];
            FechaLimite = DateTime.ParseExact(elementos[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            MedicoResponsable = elementos[5];
            Motivo = elementos[6];
            Solicita = elementos[7];
            Responsable = elementos[8];
            Comentario = elementos[9];
            EsCambioDeEstado = Convert.ToBoolean(elementos[10]);
        }

        public Pedido()
        {

        }
        public override string ToString()
        {
            return Paciente + ";" + Tecnica + ";" + Tarea + ";" + Equipo + ";" + FechaLimite.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ";" +
                MedicoResponsable + ";" + Motivo + ";" + Solicita + ";" + Responsable + ";" + Comentario + ";" + EsCambioDeEstado.ToString();
        }

        public static List<Pedido> LeerArchivo()
        {
            List<Pedido> pedidos = new List<Pedido>();
            if (File.Exists(pathPedidos))
            {
                string[] archivo = File.ReadAllLines(pathPedidos);
                if(archivo.Count()>0)
                {
                    foreach (var linea in archivo)
                    {
                        pedidos.Add(new Pedido(linea));
                    }
                }
            }
            return pedidos;
        }
        public static List<Pedido> LeerArchivoCompletados()
        {
            List<Pedido> pedidos = new List<Pedido>();
            if (File.Exists(pathPedidosCompletados))
            {
                string[] archivo = File.ReadAllLines(pathPedidosCompletados);
                if (archivo.Count() > 0)
                {
                    foreach (var linea in archivo)
                    {
                        pedidos.Add(new Pedido(linea));
                    }
                }
            }
            return pedidos;
        }
        public static void EscribirArchivo(List<Pedido> pedidos)
        {
            pedidos.OrderBy(p => p.FechaLimite);
            File.WriteAllLines(pathPedidos, pedidos.Select(p => p.ToString()));
        }
        public static void AgregarACompletados(Pedido pedidoCompletado)
        {
            List<Pedido> completados = LeerArchivoCompletados();
            completados.Add(pedidoCompletado);
            File.WriteAllLines(pathPedidosCompletados, completados.Select(p => p.ToString()));
        }
    }

    
}
