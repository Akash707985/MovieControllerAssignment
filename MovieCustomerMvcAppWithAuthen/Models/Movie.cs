using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMvcAppWithAuthen.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string   Name { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}