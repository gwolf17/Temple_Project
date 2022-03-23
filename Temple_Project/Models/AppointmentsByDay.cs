using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temple_Project.Models
{
    public class AppointmentsByDay
    {
        public string Day { get; set; }
        public List<Appointment> Appointments {get; set;}
        public DateTime Date { get; set; }
        public int Index { get; set; }
    }
}
