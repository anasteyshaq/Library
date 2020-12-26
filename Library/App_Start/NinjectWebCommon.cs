[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Library.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Library.App_Start.NinjectWebCommon), "Stop")]

namespace Library.App_Start
{
    using Library.EF.Repositories;
    using Library.Data.Repositories;
    using Library.Domain.DefaultImplementations;
    using Library.Domain.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
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
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPublicationRepository>().To<PublicationRepository>();
            kernel.Bind<ICopyRepository>().To<CopyRepository>();
            kernel.Bind<IReaderRepository>().To<ReaderRepository>();
            kernel.Bind<IStorageRepository>().To<StorageRepository>();
            kernel.Bind<ICopyService>().To<CopyService>();
        }
    }
}