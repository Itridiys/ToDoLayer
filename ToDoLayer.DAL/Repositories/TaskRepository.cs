using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using ToDoLayer.DAL.EF;
using ToDoLayer.DAL.Entities;
using ToDoLayer.DAL.Interfaces;

namespace ToDoLayer.DAL.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        private AppDbContext db;

        public TaskRepository(AppDbContext context)
        {
            this.db = context;
        }

        public void Create(Task item)
        {
            db.Tasks.Add(item);
        }

        public void Delete(int id)
        {
            Task user = db.Tasks.Find(id);
            if (user != null)
            {
                db.Tasks.Remove(user);
            }
        }

        public IEnumerable<Task> Find(Func<Task, bool> predicate)
        {
            return db.Tasks.Include(o => o.TaskStatus).Where(predicate).ToList();
        }

        public Task Get(int id)
        {
            return db.Tasks.Find(id);
        }

        public IEnumerable<Task> GetAll()
        {
            return db.Tasks.Include(o => o.TaskStatus);
        }

        public void Update(Task item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
