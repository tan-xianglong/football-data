using System;
using System.ComponentModel.DataAnnotations;

namespace EPL.Models
{
	public class Player
	{
        
        public int PlayerId { get; set; }

        [Required]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        [Required(ErrorMessage ="Please enter player's name.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Shirt Number")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int ShirtNumber { get; set; }

        [Required(ErrorMessage = "Please select player's position.")]
        public Position Position { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid number")]
        public double Height { get; set; }

        public double Weight { get; set; }

        [Required(ErrorMessage = "Please select player's year of birth.")]
        [Range(1940, 2099)]
        [Display(Name = "Year of Birth")]
        public int YearOfBirth { get; set; }

        public Team Team { get; set; }

    }
}

