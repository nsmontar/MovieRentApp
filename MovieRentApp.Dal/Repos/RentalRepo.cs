using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieRentApp.Dal.EfStructures;
using MovieRentApp.Dal.Repos.Base;
using MovieRentApp.Dal.Repos.Interfaces;
using MovieRentApp.Models.Entities;

namespace MovieRentApp.Dal.Repos
{
    public class RentalRepo : RepoBase<Rental>, IRentalRepo
    {
        public RentalRepo(RentAppContext context) : base(context)
        {
        }

        internal RentalRepo(DbContextOptions<RentAppContext> options) : base(options)
        {
        }
        public IList<Rental> GetRentalsForMovie(int id)
            => Table.Where(r => r.MovieId == id)
                    .Include(r => r.MovieNavigation)
                    .OrderByDescending(r => r.RentalDate)
                    .ToList();
        public IList<Rental> GetRentalsForUser(int id)
            => Table.Where(r => r.UserId == id)
                    .Include(r => r.UserNavigation)
                    .OrderByDescending(r => r.RentalDate)
                    .ToList();
    }
}