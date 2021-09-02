using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyProject.Models
{
    public class Coach
    {
        public int CoachID { get; set; }
        [Required(ErrorMessage = "Please enter the coach name")]
        public string CoachName { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please enter the amount of career wins for Coach")]
        public int? CareerWins { get; set; }
    }
}
