using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Temple_Project.Models
{
    public class Group
    {
        [Key]
        [Required]
        public int GroupId { get; set; }

        [Required(ErrorMessage ="Please enter a group name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the number of group members")]
        [Range(1,15)]
        public int GroupSize { get; set; }

        [Required(ErrorMessage = "Please enter an email address")]
        public string Email { get; set; }
        
        public string Phone { get; set; }

        [Required]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }  //Instance of Appointment model
    }
}
