using AriaQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipse = VMS.TPS.Common.Model.API;

namespace PlanHelper
{
    public class ConsultasEclipse
    {
        public static DateTime FechaAprobacionMedica(string PacienteID, string CursoID, string PlanID, Eclipse.Application app)
        {
            Eclipse.Patient paciente = app.OpenPatientById(PacienteID);
            string fecha = paciente.Courses.Where(c => c.Id == CursoID).First().PlanSetups.Where(p => p.Id == PlanID).First().PlanningApprovalDate;
            DateTime fechaDT;
            DateTime.TryParse(fecha, out fechaDT);
            app.ClosePatient();
            return fechaDT;
        }
    }
}
