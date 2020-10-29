using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieRentApp.Dal.EfStructures;
using MovieRentApp.Dal.Repos.Base;
using MovieRentApp.Dal.Repos.Interfaces;
using MovieRentApp.Models.Entities;

namespace MovieRentApp.Dal.Repos
{
    public class UserRepo : RepoBase<User>, IUserRepo
    {
        public UserRepo(RentAppContext context) : base(context)
        {
        }

        internal UserRepo(DbContextOptions<RentAppContext> options) : base(options)
        {
        }
    }
}