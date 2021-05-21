using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoLayer.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime CreatingDateTime { get; set; }

        public DateTime CurrentDateTime { get; set; }

        public int StatusId { get; set; }

        public virtual UserStatusDTO UserStatusDTO { get; set; }
    }
}
