[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TravelApp.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TravelApp.Web.App_Start.NinjectWebCommon), "Stop")]

namespace TravelApp.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Contracts.Interface;
    using Core.Services;
    using Data.Repositories;
    using Data.Infrastructure;
    using Entities.Model;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Data;
    using Microsoft.AspNet.Identity.Owin;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            kernel.Bind<UserManager<ApplicationUser>>().ToSelf();
            kernel.Bind<HttpContextBase>().ToMethod(ctx => new HttpContextWrapper(HttpContext.Current)).InTransientScope();
            kernel.Bind<ApplicationSignInManager>().ToMethod((context) =>
            {
                var cbase = new HttpContextWrapper(HttpContext.Current);
                return cbase.GetOwinContext().Get<ApplicationSignInManager>();
            });
            kernel.Bind<ApplicationUserManager>().ToSelf();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();          
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IAttractionRepository>().To<AttractionRepository>();
            kernel.Bind<IAttractionService>().To<AttractionService>();
            kernel.Bind<IDbFactory>().To<DbFactory>();
            kernel.Bind<ICityRepository>().To<CityRepository>();
            kernel.Bind<ICityService>().To<CityService>();
            kernel.Bind<ICountryRepository>().To<CountryRepository>();
            kernel.Bind<ICountryService>().To<CountryService>();
            kernel.Bind<IBlogRepository>().To<BlogRepository>();
            kernel.Bind<IBlogService>().To<BlogService>();
            kernel.Bind<ITripRepository>().To<TripPlanRepository>();
            kernel.Bind<ITripPlanService>().To<TripPlanService>();
            kernel.Bind<IFavouriteRepository>().To<FavouriteRepository>();
            kernel.Bind<IFavouriteService>().To<FavouriteService>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IRankRepository>().To<RankRepository>();
            kernel.Bind<IRankService>().To<RankService>();

        }
    }
}
