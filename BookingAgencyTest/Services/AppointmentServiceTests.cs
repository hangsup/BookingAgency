using System;
using System.Linq;
using BookingAgency.Models;
using BookingAgency.Repository;
using NUnit.Framework;
using Moq;
using BookingAgency.Service;
using System.Collections.Generic;

namespace BookingAgencyTest.Repositories
{
    [TestFixture]
    public class AppointmentServiceTests
    {
        private Mock<IAppointmentRepository> _repositoryMock;
        private IAppointmentService _service;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IAppointmentRepository>();
            _service = new AppointmentService(_repositoryMock.Object);
        }

        [Test]
        public void BookAppointment_Should_Add_Appointment_If_Date_Is_Valid()
        {
            var date = DateTime.Now;
            _repositoryMock.Setup(r => r.GetOffDays()).Returns(new List<OffDay>());
            _repositoryMock.Setup(r => r.GetAppointments(date)).Returns(new List<Appointment>());
            _repositoryMock.Setup(r => r.AddAppointment(It.IsAny<Appointment>())).Returns((Appointment a) => a);

            var result = _service.BookAppointment("Dion Darmawan", date);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Dion Darmawan", result.CustomerName);
            _repositoryMock.Verify(r => r.AddAppointment(It.IsAny<Appointment>()), Times.Once);
        }

        [Test]
        public void BookAppointment_Should_Throw_Exception_If_Date_Is_OffDay()
        {
            var date = DateTime.Now;
            _repositoryMock.Setup(r => r.GetOffDays()).Returns(new List<OffDay> { new OffDay { Date = date } });

            var ex = NUnit.Framework.Assert.Throws<Exception>(() => _service.BookAppointment("Dion Darmawan", date));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Selected date is an off day.", ex.Message);
        }

        [Test]
        public void AddOffDay_Should_Add_OffDay_If_Date_Is_Valid()
        {
            var date = DateTime.Now;
            _repositoryMock.Setup(r => r.GetOffDays()).Returns(new List<OffDay>());
            _repositoryMock.Setup(r => r.AddOffDay(It.IsAny<OffDay>())).Returns((OffDay a) => a);

            var result = _service.SetOffDay(date);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(date, result.Date);
            _repositoryMock.Verify(r => r.AddOffDay(It.IsAny<OffDay>()), Times.Once);
        }

        [Test]
        public void AddOffDay_Should_Throw_Exception_If_Date_Is_Already_OffDay()
        {
            var date = DateTime.Now;
            var offDay = new OffDay { Date = date };

            _repositoryMock.Setup(r => r.GetOffDays()).Returns(new List<OffDay> { offDay });

            var ex = NUnit.Framework.Assert.Throws<Exception>(() => _service.SetOffDay(date));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("The selected date is already an off day.", ex.Message);
        }
    }
}
