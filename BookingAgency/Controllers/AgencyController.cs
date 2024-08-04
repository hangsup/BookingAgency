using BookingAgency.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingAgency.Controllers
{
    public class AgencyController : Controller
    {
        private IAppointmentRepository _repository;
        public AgencyController()
        {
            if (_repository == null)
                _repository = new AppointmentRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridAppointmentsPartial() 
        {
            var appointment = _repository.GetAllAppointments();
            return PartialView("_GridAppointmentsPartial", appointment);
        }
    }
}