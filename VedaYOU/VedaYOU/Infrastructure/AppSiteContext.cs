using System;
using System.Linq;
using System.Web;
using umbraco.cms.businesslogic.web;

namespace VedaYOU.Infrastructure
{
    public class AppSiteContext : IAppSiteContext
    {
        public Domain GetCurrentDomain()
        {
            var domain = Domain.GetDomain(SiteBase + "/");
            return domain ?? Domain.GetDomains().FirstOrDefault();
        }

        public string SiteBase => CurrentContext.Request.Url?.GetLeftPart(UriPartial.Authority);

        public HttpContextBase CurrentContext => new HttpContextWrapper(HttpContext.Current);

    }
}