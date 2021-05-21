using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoLayer.Domain;

namespace ToDoLayer.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime CreatingTime { get; set; }
        public DateTime CurrentTime { get; set; }
        public int TaskStatusId { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
        public int ProviderId { get; set; }
        public int ExecutorId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public TaskStatus TasksStatus
        {
            get
            {
                return DataWorker.GetTaskStatus(TaskStatusId);
            }
        }
    }
}