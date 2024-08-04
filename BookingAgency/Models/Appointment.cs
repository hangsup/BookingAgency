using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAgency.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public int Token { get; set; }
    }
}