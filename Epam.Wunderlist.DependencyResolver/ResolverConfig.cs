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
using BLL.Concrete.Services;
using BLL.Services;
using DAL.Interfaces;
using DAL.Concrete;

namespace CustomNinjectDependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Database.SetInitializer(new InitializeEntityModel());
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();

            #region Repository binding
            kernel.Bind<IKeyRepository<TaskDal>>().To<KeyRepository<Task, TaskDal, TaskMapperDal>>().InSingletonScope();
            kernel.Bind<IKeyRepository<UserDal>>().To<KeyRepository<User, UserDal, UserMapperDal>>().InSingletonScope();
            kernel.Bind<ITaskUserRepository>().To<TaskUserRepository>().InSingletonScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            kernel.Bind<ITaskRepository>().To<TaskRepository>().InSingletonScope();
            kernel.Bind<IFolderRepository>().To<FolderRepository>().InSingletonScope();
            #endregion

            #region Service binding
            kernel.Bind<IKeyService<TaskEntity>>().To<KeyService<TaskDal, TaskEntity, IKeyRepository<TaskDal>, TaskMapper>>().InSingletonScope();
            kernel.Bind<IKeyService<UserEntity>>().To<KeyService<UserDal, UserEntity, IKeyRepository<UserDal>, UserMapper>>().InSingletonScope();
            kernel.Bind<ITaskUserService>().To<TaskUserService>().InSingletonScope();
            kernel.Bind<IUserService>().To<UserService>().InSingletonScope();
            kernel.Bind<ITaskService>().To<TaskService>().InSingletonScope();
            kernel.Bind<IFolderService>().To<FolderService>().InSingletonScope();
            #endregion

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }

        public static void Reconfiguration(this IKernel kernel)
        {
            ((EntityModel)kernel.GetService(typeof(DbContext))).Dispose();
        }
    }

}
