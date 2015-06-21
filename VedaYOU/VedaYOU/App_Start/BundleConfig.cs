using System.Web;
using System.Web.Optimization;

namespace VedaYOU.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection collection)
        {
            collection.Add(new ScriptBundle("~/bundles/css").Include("~/Content/Styles.css"));
            collection.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.9.1.js"));
            collection.Add(new ScriptBundle("~/bundles/IEscripts").Include("~/Scripts/IE/ie.styles.tricks.js"));            
        }
    }
}