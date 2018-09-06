using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int Stock { get; set; }
                
        public Genre GenreType { get; set; }        // navigation type between objects in application

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }           // entity Framework recognizes it as Foreign Key
    }
}