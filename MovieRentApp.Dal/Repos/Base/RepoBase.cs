using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieRentApp.Dal.EfStructures;
using MovieRentApp.Models.Entities.Base;

namespace MovieRentApp.Dal.Repos.Base
{
    public class RepoBase<T> : IRepo<T> where T: EntityBase, new()
    {
        public DbSet<T> Table { get; }
        public RentAppContext Context { get; }
        private readonly bool _disposeContext;

        protected RepoBase(RentAppContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }
        protected RepoBase(DbContextOptions<RentAppContext> options) 
            : this(new RentAppContext(options))
        {
            _disposeContext = true;
        }
        public virtual void Dispose()
        {
            if (_disposeContext)
            {
                Context.Dispose();
            }
        }
        public T Find(int? id) => Table.Find(id);
        public virtual IEnumerable<T> GetAll() => Table;
        public (string Schema, string TableName) TableSchemaAndName
        {
            get
            {
                var metaData = Context.Model
                    .FindEntityType(typeof(T).FullName)
                    .SqlServer();
                return (metaData.Schema, metaData.TableName);
            }
        }
        public bool HasChanges => Context.ChangeTracker.HasChanges();

        public virtual int Add(T entity, bool persist = true)
        {
            Table.Add(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int AddRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.AddRange(entities);
            return persist ? SaveChanges() : 0;
        }
        public virtual int Update(T entity, bool persist = true)
        {
            Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int UpdateRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.UpdateRange(entities);
            return persist ? SaveChanges() : 0;
        }
        public virtual int Delete(T entity, bool persist = true)
        {
            Table.Remove(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int DeleteRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.RemoveRange(entities);
            return persist ? SaveChanges() : 0;
        }
        public int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO: log and handle intelligently
                throw ex;
            }
        }
    }
}