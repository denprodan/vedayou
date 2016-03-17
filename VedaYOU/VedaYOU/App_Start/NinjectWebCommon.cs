using AutoMapper;
using Umbraco.Core;
using Umbraco.Web;
using VedaYOU.Core.Interfaces;
using VedaYOU.Core.Services;
using VedaYOU.Infrastructure;
using VedaYOU.Infrastructure.AutoMapperProfiles;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VedaYOU.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VedaYOU.App_Start.NinjectWebCommon), "Stop")]

namespace VedaYOU.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
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
            // umbraco
            kernel.Bind<UmbracoContext>()
                .ToMethod(context => CreateUmbracoContext())
                .InRequestScope();
            kernel.Bind<UmbracoHelper>().ToSelf()
                .InRequestScope();

            kernel.Bind<IPageService>().To<PageService>().InRequestScope();
            kernel.Bind<IAppSiteContext>().To<AppSiteContext>().InSingletonScope();
        }
      
        private static UmbracoContext CreateUmbracoContext()
        {
            var context = HttpContext.Current != null ? HttpContext.Current : new HttpContext(new HttpRequest("", "http://localhost/", ""), new HttpResponse(null));
            var result = UmbracoContext.EnsureContext(new HttpContextWrapper(context),
                    ApplicationContext.Current);
            return result;
        }
    }

    public static class MapperConfig
    {
        public static void RegisterProfiles()
        {
            Mapper.AddProfile<ArticleAutoMapperProfile>();
        }

    }
}
