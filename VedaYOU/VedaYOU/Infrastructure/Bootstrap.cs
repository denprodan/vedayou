using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Umbraco.Web;
using VedaYOU.App_Start;

namespace VedaYOU.Infrastructure
{
    public class Bootstrap : UmbracoApplication
    {
        protected override void OnApplicationStarting(object sender, EventArgs e)
        {
            Start();         
        }

        public void Start()
        {            
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);       
            MapperConfig.RegisterProfiles();     
        }
    }
}