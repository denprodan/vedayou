using System.Web;
using System.Web.Optimization;

namespace VedaYOU.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection collection)
        {
            collection.Add(new ScriptBundle("~/bundles/css").Include("~/Content/Styles.css"));
            
        }
    }
}