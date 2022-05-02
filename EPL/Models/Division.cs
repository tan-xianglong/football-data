using System;
using System.ComponentModel.DataAnnotations;

namespace EPL.Models
{
	public class Division
	{
        public int DivisionId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

