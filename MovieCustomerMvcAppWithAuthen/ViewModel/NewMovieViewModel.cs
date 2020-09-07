using MovieCustomerMvcAppWithAuthen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMvcAppWithAuthen.ViewModel
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> GenreType { get; set; }
        //public Movie Movie { get; set; }
        public int ?Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public Genre Genre { get; set; }
        public int ?GenreId { get; set; }
        public string Title
        {
            get
            {
                return Id != 0?"Edit Movie":"New Movie";
            }
        }
        public NewMovieViewModel()
        {
            Id = 0;
        }
        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
        }
    }
}