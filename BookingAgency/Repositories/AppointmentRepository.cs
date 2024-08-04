using BookingAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAgency.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private static List<Appointment> appointments = new List<Appointment>();
        private static List<OffDay> offDays = new List<OffDay>();

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return appointments.ToList();
        }

        public IEnumerable<Appointment> GetAppointments(DateTime date)
        {
            return appointments.Where(a => a.Date.Date == date.Date).ToList();
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            appointment.Id = appointments.Count + 1;
            appointments.Add(appointment);
            return appointment;
        }

        public IEnumerable<OffDay> GetOffDays()
        {
            return offDays.ToList();
        }

        public OffDay AddOffDay(OffDay offDay)
        {
            offDays.Add(offDay);
            return offDay;
        }
    }

}