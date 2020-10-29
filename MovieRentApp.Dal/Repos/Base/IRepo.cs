using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieRentApp.Dal.EfStructures;
using MovieRentApp.Models.Entities.Base;

namespace MovieRentApp.Dal.Repos.Base
{
    public interface IRepo<T> : IDisposable where T: EntityBase
    {
        DbSet<T> Table { get; }
        RentAppContext Context { get; }
        (string Schema, string TableName) TableSchemaAndName { get; }
        bool HasChanges { get; }
        T Find(int? id);
        IEnumerable<T> GetAll();
        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
        int Delete(T entity, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        int SaveChanges();
    }
}