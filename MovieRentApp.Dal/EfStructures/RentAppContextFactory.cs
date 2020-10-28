using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MovieRentApp.Dal.EfStructures
{
  public class RentAppContextFactory : IDesignTimeDbContextFactory<RentAppContext>
  {
    public RentAppContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<RentAppContext>();
      var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=MovieRentApp21;Trusted_Connection=True;MultipleActiveResultSets=true;";
      optionsBuilder
        .UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
      optionsBuilder
        .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
      Console.WriteLine(connectionString);
      return new RentAppContext(optionsBuilder.Options);
    }
  }
}