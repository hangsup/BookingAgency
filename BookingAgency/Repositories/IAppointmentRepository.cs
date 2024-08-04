using BookingAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAgency.Repository
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointments();
        IEnumerable<Appointment> GetAppointments(DateTime date);
        Appointment AddAppointment(Appointment appointment);
        IEnumerable<OffDay> GetOffDays();
        OffDay AddOffDay(OffDay offDay);
    }
}
