using BookingAgency.Models;
using BookingAgency.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAgency.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private static int tokenCounter = 1;
        private static int maxAppointmentsPerDay = 5;

        //This is for using DI such as Autofac or Unity
        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public AppointmentService()
        {
            if(_repository == null) _repository = new AppointmentRepository();
        }

        public Appointment BookAppointment(string customerName, DateTime date)
        {
            var offDays = _repository.GetOffDays();
            if (offDays.Any(d => d.Date.Date == date.Date))
            {
                throw new Exception("Selected date is an off day.");
            }

            var appointmentsForDay = _repository.GetAppointments(date);
            if (appointmentsForDay.Count() >= maxAppointmentsPerDay)
            {
                date = date.AddDays(1);
                return BookAppointment(customerName, date);
            }

            var appointment = new Appointment
            {
                CustomerName = customerName,
                Date = date,
                Token = tokenCounter++
            };
            return _repository.AddAppointment(appointment);
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _repository.GetAllAppointments();
        }

        public IEnumerable<Appointment> GetAppointments(DateTime date)
        {
            return _repository.GetAppointments(date);
        }

        public OffDay SetOffDay(DateTime date)
        {
            var offDays = _repository.GetOffDays();
            if (offDays.Any(d => d.Date.Date == date.Date))
            {
                throw new Exception("The selected date is already an off day.");
            }
            return _repository.AddOffDay(new OffDay { Date = date });
        }

        public IEnumerable<OffDay> GetOffDays()
        {
            return _repository.GetOffDays();
        }
    }

}
