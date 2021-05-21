using System;
using ToDoLayer.DAL.EF;
using ToDoLayer.DAL.Entities;
using ToDoLayer.DAL.Interfaces;
using TaskStatus = ToDoLayer.DAL.Entities.TaskStatus;

namespace ToDoLayer.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AppDbContext db;
        private UserRepository userRepository;
        private UserStatusRepository userStatusRepository;
        private TaskStatusRepository taskStatusRepository;
        private TaskRepository taskRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new AppDbContext(connectionString);
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<UserStatus> UserStatuses
        {
            get
            {
                if (userStatusRepository == null)
                    userStatusRepository = new UserStatusRepository(db);
                return userStatusRepository;
            }
        }

        public IRepository<TaskStatus> TaskStatuses
        {
            get
            {
                if (taskStatusRepository == null)
                    taskStatusRepository = new TaskStatusRepository(db);
                return taskStatusRepository;
            }
        }

        public IRepository<Entities.Task> Tasks
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(db);
                return taskRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
