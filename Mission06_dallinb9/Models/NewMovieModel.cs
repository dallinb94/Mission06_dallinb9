using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_dallinb9.Models
{
    public class NewMovieModel
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "You must enter a Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must enter a Year")]
        [Range(1900, 2100, ErrorMessage = "The year must be between 1900 and 2100")]
        public int Year { get; set; }

        [Required(ErrorMessage = "You must enter a Director")]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public string Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }

        //Build ForeignKey Relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
