using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using BookingAgency.Service;
using BookingAgency.Controllers;
using BookingAgency.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace BookingAgencyTest.Controllers {
    
    [TestFixture]
    public class AppointmentsControllerTests
    {
        private Mock<IAppointmentService> _serviceMock;
        private AppointmentsController _controller;

        [SetUp]
        public void SetUp()
        {
            _serviceMock = new Mock<IAppointmentService>();
            _controller = new AppointmentsController(_serviceMock.Object);
        }

        [Test]
        public void BookAppointment_Should_Return_Ok_With_Appointment_When_Successful()
        {
            // Arrange
            var customerName = "John Doe";
            var date = DateTime.Now;
            var appointment = new Appointment { CustomerName = customerName, Date = date, Token = 1 };
            _serviceMock.Setup(s => s.BookAppointment(customerName, date)).Returns(appointment);

            // Act
            IHttpActionResult actionResult = _controller.BookAppointment(customerName, date);
            var contentResult = actionResult as OkNegotiatedContentResult<Appointment>;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(contentResult);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(contentResult.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, contentResult.Content.Token);
        }

        [Test]
        public void BookAppointment_Should_Return_BadRequest_When_Exception_Occurs()
        {
            // Arrange
            var customerName = "John Doe";
            var date = DateTime.Now;
            _serviceMock.Setup(s => s.BookAppointment(customerName, date)).Throws(new Exception("Error"));

            // Act
            IHttpActionResult actionResult = _controller.BookAppointment(customerName, date);
            var badRequestResult = actionResult as BadRequestErrorMessageResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(badRequestResult);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Error", badRequestResult.Message);
        }

        [Test]
        public void GetAppointments_Should_Return_Ok_With_Appointments()
        {
            // Arrange
            var date = DateTime.Now;
            var appointments = new List<Appointment>
        {
            new Appointment { CustomerName = "John Doe", Date = date, Token = 1 }
        };
            _serviceMock.Setup(s => s.GetAppointments(date)).Returns(appointments);

            // Act
            IHttpActionResult actionResult = _controller.GetAppointments(date);
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<Appointment>>;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(contentResult);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(contentResult.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, ((List<Appointment>)contentResult.Content).Count);
        }

        [Test]
        public void SetOffDay_Should_Return_Ok_With_OffDay()
        {
            // Arrange
            var date = DateTime.Now;
            var offDay = new OffDay { Date = date };
            _serviceMock.Setup(s => s.SetOffDay(date)).Returns(offDay);

            // Act
            IHttpActionResult actionResult = _controller.SetOffDay(date);
            var contentResult = actionResult as OkNegotiatedContentResult<OffDay>;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(contentResult);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(contentResult.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(date, contentResult.Content.Date);
        }

        [Test]
        public void GetOffDays_Should_Return_Ok_With_OffDays()
        {
            // Arrange
            var offDays = new List<OffDay>
        {
            new OffDay { Date = DateTime.Now }
        };
            _serviceMock.Setup(s => s.GetOffDays()).Returns(offDays);

            // Act
            IHttpActionResult actionResult = _controller.GetOffDays();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<OffDay>>;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(contentResult);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(contentResult.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, ((List<OffDay>)contentResult.Content).Count);
        }
    }

}
