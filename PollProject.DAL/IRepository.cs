using System;
using System.Linq;
using PollProject.Domain;

namespace PollProject.DAL
{
    public interface IRepository : IDisposable
    {
        T SelectById<T>(int id) where T : Entity;

        IQueryable<T> Select<T>() where T : Entity;

        void Add<T>(T entity) where T : Entity;

        void SaveChanges();
    }
}
