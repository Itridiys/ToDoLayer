using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoLayer.DAL.EF;
using ToDoLayer.DAL.Entities;
using ToDoLayer.DAL.Interfaces;

namespace ToDoLayer.DAL.Repositories
{
    public class UserStatusRepository : IRepository<UserStatus>
    {
        private AppDbContext db;

        public UserStatusRepository(AppDbContext context)
        {
            this.db = context;
        }

        public void Create(UserStatus item)
        {
            db.UserStatuses.Add(item);
        }

        public void Delete(int id)
        {
            UserStatus user = db.UserStatuses.Find(id);
            if (user != null)
            {
                db.UserStatuses.Remove(user);
            }
        }

        public IEnumerable<UserStatus> Find(Func<UserStatus, bool> predicate)
        {
            return db.UserStatuses.Where(predicate).ToList();
        }

        public UserStatus Get(int id)
        {
            return db.UserStatuses.Find(id);
        }

        public IEnumerable<UserStatus> GetAll()
        {
            return db.UserStatuses;
        }

        public void Update(UserStatus item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
