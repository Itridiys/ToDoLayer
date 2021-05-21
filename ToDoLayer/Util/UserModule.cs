using Ninject.Modules;
using ToDoLayer.BLL.Interfaces;
using ToDoLayer.BLL.Services;

namespace ToDoLayer.Util
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}