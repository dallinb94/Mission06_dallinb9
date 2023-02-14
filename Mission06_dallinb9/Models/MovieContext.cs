using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_dallinb9.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            
        }

        public DbSet<NewMovieModel> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<NewMovieModel>().HasData(
            new NewMovieModel
            {
                MovieID = 1,
                Category = "Sci-fi",
                Title = "Interstellar",
                Year = 2014,
                Director = "Christopher Nolan",
                Rating = "PG-13",
                Edited = "",
                LentTo = "",
                Notes = "",
            });
        }
    }
}
