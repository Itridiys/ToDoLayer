using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoLayer.ViewModels
{
    public class UsersWithStarusViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public IEnumerable<UserStatusViewModel> UserStatus { get; set; }
    }
}