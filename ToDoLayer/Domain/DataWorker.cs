using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoLayer.Models;

namespace ToDoLayer.Domain
{
    public static class DataWorker
    {
        internal static UserStatus GetUserStatus(int statusId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                UserStatus status = db.Statuses.FirstOrDefault(p => p.Id == statusId);
                return status;
            }
        }

        internal static TaskStatus GetTaskStatus(int taskStatusId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                TaskStatus status = db.TaskStatuses.FirstOrDefault(p => p.Id == taskStatusId);
                return status;
            }
        }
    }
}