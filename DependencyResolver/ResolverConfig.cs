using System.Data.Entity;
using Ninject.Web.Common;
using Ninject;
using ORM;
using DAL.Interfaces.Repositories;
using DAL.Concrete.Entities;
using DAL.Concrete.Repositories;
using DAL.Concrete.Mappers;
using BLL.Interfaces.Services;
using BLL.Concrete.Entities;
using BLL;
using DAL.Interfaces;
using DAL.Concrete;

namespace CustomNinjectDependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Database.SetInitializer<EntityModel>(new InitializeEntityModel());
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();

            kernel.Bind<IKeyRepository<TaskDAL>>().To<KeyRepository<Task, TaskDAL, TaskMapperDAL>>();
            kernel.Bind<IKeyRepository<UserDAL>>().To<KeyRepository<User, UserDAL, UserMapperDAL>>();
            kernel.Bind<ITaskUserRepository>().To<TaskUserRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<IKeyService<TaskEntity>>().To<KeyService<TaskDAL, TaskEntity, IKeyRepository<TaskDAL>, TaskMapper>>();
            kernel.Bind<IKeyService<UserEntity>>().To<KeyService<UserDAL, UserEntity, IKeyRepository<UserDAL>, UserMapper>>();
            kernel.Bind<ITaskUserService>().To<TaskUserService>();
            kernel.Bind<IUserService>().To<UserService>();


            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }

        public static void Reconfiguration(this IKernel kernel)
        {
            ((EntityModel)kernel.GetService(typeof(DbContext))).Dispose();
        }
    }

}
