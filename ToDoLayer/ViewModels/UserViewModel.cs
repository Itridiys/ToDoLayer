using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoLayer.Domain;
using ToDoLayer.Models;

namespace ToDoLayer.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime CreatingDateTime { get; set; }

        public DateTime CurrentDateTime { get; set; }

        public int StatusId { get; set; }

        public virtual UserStatus Status { get; set; }

        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //public UserStatus UserStatus
        //{
        //    get
        //    {
        //        return DataWorker.GetUserStatus(StatusId);
        //    }
        //}
    }
}