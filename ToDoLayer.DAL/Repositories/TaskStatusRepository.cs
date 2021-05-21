using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoLayer.DAL.EF;
using ToDoLayer.DAL.Entities;
using ToDoLayer.DAL.Interfaces;

namespace ToDoLayer.DAL.Repositories
{
    public class TaskStatusRepository : IRepository<TaskStatus>
    {
        private AppDbContext db;

        public TaskStatusRepository(AppDbContext context)
        {
            this.db = context;
        }

        public void Create(TaskStatus item)
        {
            db.TaskStatuses.Add(item);
        }

        public void Delete(int id)
        {
            TaskStatus user = db.TaskStatuses.Find(id);
            if (user != null)
            {
                db.TaskStatuses.Remove(user);
            }
        }

        public IEnumerable<TaskStatus> Find(Func<TaskStatus, bool> predicate)
        {
            return db.TaskStatuses.Where(predicate).ToList();
        }

        public TaskStatus Get(int id)
        {
            return db.TaskStatuses.Find(id);
        }

        public IEnumerable<TaskStatus> GetAll()
        {
            return db.TaskStatuses;
        }

        public void Update(TaskStatus item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
