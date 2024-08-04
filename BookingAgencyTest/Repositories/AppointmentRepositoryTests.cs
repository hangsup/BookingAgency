using System;
using System.Linq;
using BookingAgency.Models;
using BookingAgency.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace BookingAgencyTest.Repositories
{
    [TestFixture]
    public class AppointmentRepositoryTests
    {
        private IAppointmentRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new AppointmentRepository();
        }

        [Test]
        public void AddAppointment_Should_Add_Appointment()
        {
            var appointment = new Appointment { CustomerName = "Dion Darmawan", Date = DateTime.Now };
            var result = _repository.AddAppointment(appointment);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, result.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Dion Darmawan", result.CustomerName);
        }

        [Test]
        public void GetAppointments_Should_Return_Appointments_For_Given_Date()
        {
            var date = DateTime.Now;
            _repository.AddAppointment(new Appointment { CustomerName = "Dion Darmawan", Date = date });

            var result = _repository.GetAppointments(date);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void AddOffDays_Should_Add_OffDays()
        {
            var date = DateTime.Now; 
            var offDay = new OffDay();
            offDay.Date = date;
            var result = _repository.AddOffDay(offDay);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(date, offDay.Date);
        }
    }

}
