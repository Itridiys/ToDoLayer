using System.ComponentModel.DataAnnotations;

namespace ToDoLayer.DAL.Entities
{
    public class UserStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
