using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyProject.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        [Required(ErrorMessage = "Please enter a player name")]
        public string PlayerName { get; set; }
        [Required(ErrorMessage = "Please enter the player's position")]
        public string Position { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please enter an amount of goals")]
        public int? Goals { get; set; }
        [Required(ErrorMessage = "Please enter an amount of assists")]
        public int? Assists { get; set; }

        public int FindPoints()
        {
            int points = (int)(Goals + Assists);
            return points;
        }
        
    }
}
