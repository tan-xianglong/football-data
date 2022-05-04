using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EPL.Models
{
	public class Team
	{
        public int TeamId { get; set; }

        [Required]
        public int DivisionId { get; set; }

        [Required(ErrorMessage = "Please enter the team's name.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the team's home location.")]
        [StringLength(50)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter the stadium name.")]
        [StringLength(100)]
        public string Stadium { get; set; }

        public Division Division { get; set; }

        public ICollection<Player> Players { get; set; }

    }
}

