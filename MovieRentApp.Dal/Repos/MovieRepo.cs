using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieRentApp.Dal.EfStructures;
using MovieRentApp.Dal.Repos.Base;
using MovieRentApp.Dal.Repos.Interfaces;
using MovieRentApp.Models.Entities;

namespace MovieRentApp.Dal.Repos
{
    public class MovieRepo : RepoBase<Movie>, IMovieRepo
    {
        public MovieRepo(RentAppContext context) : base(context)
        {
        }

        internal MovieRepo(DbContextOptions<RentAppContext> options) : base(options)
        {
        }
    }
}