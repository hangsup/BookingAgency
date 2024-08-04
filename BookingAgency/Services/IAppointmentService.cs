using BookingAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAgency.Service
{
    public interface IAppointmentService
    {
        Appointment BookAppointment(string customerName, DateTime date);
        IEnumerable<Appointment> GetAllAppointments();
        IEnumerable<Appointment> GetAppointments(DateTime date);
        OffDay SetOffDay(DateTime date);
        IEnumerable<OffDay> GetOffDays();
    }
}
