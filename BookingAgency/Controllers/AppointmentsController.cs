using BookingAgency.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookingAgency.Controllers
{
    public class AppointmentsController : ApiController
    {
        /// <summary>
        /// Controller for managing appointments.
        /// </summary>
        private readonly IAppointmentService _service;

        //This is for using DI such as Autofac or Unity
        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        //i Will use the conventional one
        public AppointmentsController()
        {
            if (_service == null)
                _service = new AppointmentService();
        }

        /// <summary>
        /// Books an appointment for a customer.
        /// </summary>
        /// <param name="request">The appointment request containing customer name and date.</param>
        /// <returns>The booked appointment details.</returns>
        [Route("api/Appointments/BookAppointment/{customerName}/{date}")]
        [HttpPost,HttpGet]
        public IHttpActionResult BookAppointment(string customerName, DateTime date)
        {
            try
            {
                var appointment = _service.BookAppointment(customerName, date);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get All Data for Customer Appointments
        /// </summary>
        /// <returns>All data customer appointments</returns>
        [Route("api/Appointments/GetAllAppointments")]
        [HttpGet]
        public IHttpActionResult GetAllAppointments()
        {
            var appointments = _service.GetAllAppointments();
            return Ok(appointments);
        }

        /// <summary>
        /// Get Data for Customer Appointments By Specific Date
        /// </summary>
        /// <returns>Data customer appointments by date</returns>
        [Route("api/Appointments/GetAppointments/{date}")]
        [HttpGet]
        public IHttpActionResult GetAppointments(DateTime date)
        {
            var appointments = _service.GetAppointments(date);
            return Ok(appointments);
        }

        /// <summary>
        /// Set Off Day
        /// </summary>
        /// <returns>The date for off day</returns>
        [Route("api/Appointments/SetOffDay/{date}")]
        [HttpPost,HttpGet]
        public IHttpActionResult SetOffDay(DateTime date)
        {
            try { 
                var offDay = _service.SetOffDay(date);
                return Ok(offDay);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Off Days
        /// </summary>
        /// <returns>List dates for all off days</returns>
        [Route("api/Appointments/GetOffDays")]
        [HttpGet]
        public IHttpActionResult GetOffDays()
        {
            var offDays = _service.GetOffDays();
            return Ok(offDays);
        }
    }

}
