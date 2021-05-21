using System;
using ToDoLayer.DAL.Entities;

namespace ToDoLayer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<TaskStatus> TaskStatuses { get; }
        IRepository<UserStatus> UserStatuses { get; }
        IRepository<Task> Tasks { get; }
        void Save();
    }
}
