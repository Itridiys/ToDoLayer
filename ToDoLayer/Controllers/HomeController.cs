using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToDoLayer.BLL.DTO;
using ToDoLayer.BLL.Infrastructure;
using ToDoLayer.BLL.Interfaces;
using ToDoLayer.ViewModels;

namespace ToDoLayer.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService;
        public HomeController(IUserService user)
        {
            userService = user;
        }
        public ActionResult Index()
        {
            IEnumerable<UserDTO> userDto = userService.GetUsers();
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapperUser.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDto);

            IEnumerable<UserStatusDTO> statusDto = userService.GetStatus();
            var mapperStatus = new MapperConfiguration(cfg => cfg.CreateMap<UserStatusDTO, UserStatusViewModel>()).CreateMapper();
            var statuses = mapperStatus.Map<IEnumerable<UserStatusDTO>, List<UserStatusViewModel>>(statusDto);

            UsersWithStarusViewModel viewModel = new UsersWithStarusViewModel
            {
                Users = users,
                UserStatus = statuses
            };

            return View(viewModel);
        }

        public ActionResult GetUser(int? id)
        {
            try
            {
                UserStatusDTO status = userService.GetStatus(id);
                var order = new UserViewModel { StatusId = status.Id };

                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult GetUser(UserViewModel order)
        {
            try
            {
                var userDto = new UserDTO { Name = order.Name, Surname = order.Surname, StatusId = order.StatusId };
                userService.GetUser(userDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

        protected override void Dispose(bool disposing)
        {
            userService.Dispose();
            base.Dispose(disposing);
        }
    }
}