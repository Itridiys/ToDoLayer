using System;
using System.Data.Entity;
using ToDoLayer.Models;

namespace ToDoLayer.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserStatus> Statuses { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<Task> Tasks { get; set; }


        public class StoreDbInitializer : DropCreateDatabaseAlways<AppDbContext>
        {
            protected override void Seed(AppDbContext db)
            {
                db.Users.Add(new User { Id = 1, Name = "Никита", Surname = "Антонов", CreatingDateTime = DateTime.Now, CurrentDateTime = DateTime.Now, StatusId = 1 });
                db.Users.Add(new User { Id = 2, Name = "Мария", Surname = "Иванова", CreatingDateTime = DateTime.Now, CurrentDateTime = DateTime.Now, StatusId = 1 });
                db.Users.Add(new User { Id = 3, Name = "Виолета", Surname = "Смирнова", CreatingDateTime = DateTime.Now, CurrentDateTime = DateTime.Now, StatusId = 1 });
                db.Users.Add(new User { Id = 4, Name = "Иван", Surname = "Иванов", CreatingDateTime = DateTime.Now, CurrentDateTime = DateTime.Now, StatusId = 1 });
                db.Users.Add(new User { Id = 5, Name = "Семён", Surname = "Машков", CreatingDateTime = DateTime.Now, CurrentDateTime = DateTime.Now, StatusId = 1 });

                db.Statuses.Add(new UserStatus { Id = 1, Name = "Активен" });
                db.Statuses.Add(new UserStatus { Id = 2, Name = "Отключен" });
                db.Statuses.Add(new UserStatus { Id = 3, Name = "Заблокирован" });                

                db.TaskStatuses.Add(new TaskStatus { Id = 1, Name = "Не начата" });
                db.TaskStatuses.Add(new TaskStatus { Id = 2, Name = "В процессе" });
                db.TaskStatuses.Add(new TaskStatus { Id = 3, Name = "Выполнена" });
                db.TaskStatuses.Add(new TaskStatus { Id = 4, Name = "Отменена" });
                db.TaskStatuses.Add(new TaskStatus { Id = 5, Name = "Отклонена" });


                db.SaveChanges();
            }
        }   
                
    }
}