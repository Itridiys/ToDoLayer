using AutoMapper;
using System;
using System.Collections.Generic;
using ToDoLayer.BLL.DTO;
using ToDoLayer.BLL.Infrastructure;
using ToDoLayer.BLL.Interfaces;
using ToDoLayer.DAL.Entities;
using ToDoLayer.DAL.Interfaces;

namespace ToDoLayer.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public UserStatusDTO GetStatus(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id статуса", "");
            var status = Database.UserStatuses.Get(id.Value);
            if (status == null)
                throw new ValidationException("Статус не найден", "");

            return new UserStatusDTO { Id = status.Id, Name = status.Name };
        }

        public IEnumerable<UserStatusDTO> GetStatus()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserStatus, UserStatusDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserStatus>, List<UserStatusDTO>>(Database.UserStatuses.GetAll());
        }

        public void GetUser(UserDTO userDto)
        {
            UserStatus status = Database.UserStatuses.Get(userDto.StatusId);

            // валидация
            if (status == null)
                throw new ValidationException("Статус не найден", "");

            // Сохраняем пользователя
            User user = new User
            {
                CreatingDateTime = DateTime.Now,
                CurrentDateTime = DateTime.Now,
                Name = userDto.Name,
                Surname = userDto.Surname,
                StatusId = userDto.StatusId
            };
            Database.Users.Create(user);


            Database.Save();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }
    }
}
