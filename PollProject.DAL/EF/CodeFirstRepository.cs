using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PollProject.Domain;

namespace PollProject.DAL.EF
{
    public class CodeFirstRepository : DbContext, IRepository
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Poll> Polls { get; set; }

        public CodeFirstRepository() : base("PollDatabase") {}

        public T SelectById<T>(int id) where T : Entity
        {
            Expression<Func<T, bool>> selectExpression = x => x.Id == id;
            T entity = Set<T>().Single(selectExpression);

            return entity;
        }

        public IQueryable<T> Select<T>() where T : Entity
        {
            return Set<T>();
        }

        public void Add<T>(T entity) where T : Entity
        {
            Set<T>().Add(entity);
        }

        void IRepository.SaveChanges()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new PollDataSeedInitializer());
        }
    }
}