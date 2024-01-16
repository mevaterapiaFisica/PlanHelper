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

        public DateTime fechaCarga { get; set; }
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
        public string TareaInicial { get; set; }

        public override bool Equals(object obj)
        {
            return (fechaCarga == ((Pedido)obj).fechaCarga && Paciente == ((Pedido)obj).Paciente && Tecnica == ((Pedido)obj).Tecnica && Equipo == ((Pedido)obj).Equipo);
        }
        public Pedido(string linea)
        {
            string[] elementos = linea.Split(';');
            fechaCarga = DateTime.ParseExact(elementos[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Paciente = elementos[1];
            Tecnica = elementos[2];
            Tarea = elementos[3];
            Equipo = elementos[4];
            FechaLimite = DateTime.ParseExact(elementos[5], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            MedicoResponsable = elementos[6];
            Motivo = elementos[7];
            Solicita = elementos[8];
            Responsable = elementos[9];
            Comentario = elementos[10];
            TareaInicial = elementos[11];
        }

        public Pedido()
        {

        }
        public override string ToString()
        {
            return fechaCarga.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ";" + Paciente + ";" + Tecnica + ";" + Tarea + ";" + Equipo + ";" + FechaLimite.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ";" +
                MedicoResponsable + ";" + Motivo + ";" + Solicita + ";" + Responsable + ";" + Comentario + ";" + TareaInicial;
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
