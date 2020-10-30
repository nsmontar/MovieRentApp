
using System.Collections.Generic;
using MovieRentApp.Dal.Repos.Base;
using MovieRentApp.Models.Entities;

namespace MovieRentApp.Dal.Repos.Interfaces
{
    public interface IRentalRepo : IRepo<Rental>
    {
        IList<Rental> GetRentalsForMovie(int id);
        IList<Rental> GetRentalsForUser(int id);
    }
}