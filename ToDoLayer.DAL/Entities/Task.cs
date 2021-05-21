using System;
using System.ComponentModel.DataAnnotations;


namespace ToDoLayer.DAL.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime CreatingTime { get; set; }
        public DateTime CurrentTime { get; set; }
        public int TaskStatusId { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
        public int ProviderId { get; set; }
        public int ExecutorId { get; set; }
    }
}
