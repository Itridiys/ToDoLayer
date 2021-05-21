using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ToDoLayer.DAL.EF;
using ToDoLayer.DAL.Entities;
using ToDoLayer.DAL.Interfaces;

namespace ToDoLayer.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private AppDbContext db;

        public UserRepository(AppDbContext context)
        {
            this.db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Include(o => o.Status).Where(predicate).ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.Include(o => o.Status);
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
