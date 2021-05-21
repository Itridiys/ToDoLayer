using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoLayer.DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime CreatingDateTime { get; set; }

        public DateTime CurrentDateTime { get; set; }

        public int StatusId { get; set; }

        public virtual UserStatus Status { get; set; }
    }
}
