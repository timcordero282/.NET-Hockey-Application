using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyProject.Models
{
    public class Team
    {
        public int TeamID{ get; set; }
        [Required(ErrorMessage ="Please enter a team name")]
        public string TeamName { get; set; }
   
        [Required(ErrorMessage ="Please select a Conference")]
        public string Conference { get; set; }
        [Required(ErrorMessage = "Please eneter an amount of wins")]
        [Range(0, 82)]
        public int? Wins { get; set; }
        [Required(ErrorMessage = "Please eneter an amount of losses")]
        [Range(0, 82)]
        public int? Losses { get; set; }

        // link to players
         [Required(ErrorMessage = "Please select a Captain")]
        public int? PlayerID { get; set; }
        public Player PlayerName { get; set; }

        // link to coach
        [Required(ErrorMessage = "Please select a Coach")]
        public int? CoachID { get; set; }
        public Coach CoachName { get; set; }


        public decimal WinningPCT()
        {
            decimal WinningPRCT = Decimal.Divide((decimal)Wins, (decimal)(Wins + Losses));
            WinningPRCT = WinningPRCT * 100;
            WinningPRCT = Math.Round(WinningPRCT, 2);
            return WinningPRCT;
        }
    }
}
