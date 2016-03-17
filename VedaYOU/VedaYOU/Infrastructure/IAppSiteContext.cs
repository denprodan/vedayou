using System.Web;
using umbraco.cms.businesslogic.web;

namespace VedaYOU.Infrastructure
{
    public interface IAppSiteContext
    {
        Domain GetCurrentDomain();

        string SiteBase { get; }

        HttpContextBase CurrentContext { get; }
    }
}