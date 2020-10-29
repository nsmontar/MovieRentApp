using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieRentApp.Dal.EfStructures;
using MovieRentApp.Dal.Repos.Base;
using MovieRentApp.Models.Entities;

namespace MovieRentApp.Dal.Repos
{
    public class RentalRepo : RepoBase<User> 
    {
        public RentalRepo(RentAppContext context) : base(context)
        {
        }

        internal RentalRepo(DbContextOptions<RentAppContext> options) : base(options)
        {
        }
    }
}