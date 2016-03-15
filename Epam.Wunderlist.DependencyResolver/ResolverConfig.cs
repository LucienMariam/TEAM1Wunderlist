#region Namespaces 
using System.Data.Entity;
using Ninject.Web.Common;
using Ninject;
using ORM;
using DataAccess.Interfaces;
using DataAccess.MsSql.Repositories;
using TaskService;
using UserService;
using FolderService;
using DataAccess.MsSql;
#endregion

namespace CustomNinjectDependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Database.SetInitializer(new InitializeEntityModel());
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();

            #region Repository binding
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ITaskRepository>().To<TaskRepository>();
            kernel.Bind<IFolderRepository>().To<FolderRepository>();
            #endregion

            #region Service binding
            kernel.Bind<IUserService>().To<UserService.UserService>();
            kernel.Bind<ITaskService>().To<TaskService.TaskService>();
            kernel.Bind<IFolderService>().To<FolderService.FolderService>();
            #endregion

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }

        public static void Reconfiguration(this IKernel kernel)
        {
            ((EntityModel)kernel.GetService(typeof(DbContext))).Dispose();
        }
    }

}
