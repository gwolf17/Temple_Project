using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Temple_Project.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int AppointmentId { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public bool Available { get; set; }
    }
}
