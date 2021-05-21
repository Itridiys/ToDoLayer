using System.ComponentModel.DataAnnotations;

namespace ToDoLayer.DAL.Entities
{
    public class TaskStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
