using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModels
    {
        public List<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        
        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int? Stock { get; set; }
        
        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }           // entity Framework recognizes it as Foreign Key

        public String Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        // this will be used when creating a new Movie
        public MovieFormViewModels()
        {
            Id = 0;
        }

        // this will be used when editing an existing Movie
        public MovieFormViewModels(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }
    }
}