using System.Collections.Generic;
using ToDoLayer.BLL.DTO;

namespace ToDoLayer.BLL.Interfaces
{
    public interface IUserService
    {
        void GetUser(UserDTO userDto);
        IEnumerable<UserDTO> GetUsers();
        UserStatusDTO GetStatus(int? id);
        IEnumerable<UserStatusDTO> GetStatus();
        void Dispose();
    }
}
