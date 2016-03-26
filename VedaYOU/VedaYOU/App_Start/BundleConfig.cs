using System.Web;
using System.Web.Optimization;

namespace VedaYOU.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection collection)
        {
            collection.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.9.1.js"));
            collection.Add(new ScriptBundle("~/bundles/fitText").Include("~/Scripts/fitText.js"));
            collection.Add(new ScriptBundle("~/bundles/scripts").Include("~/Scripts/IE/ie.styles.tricks.js"));
            collection.Add(new ScriptBundle("~/bundles/scripts").Include("~/Scripts/IE/commonScripts.js"));
            collection.Add(new ScriptBundle("~/bundles/scrolling").Include("~/Scripts/scrolling.js"));            

            collection.Add(new StyleBundle("~/bundles/styles")
                .Include(
                "~/Content/Styles.css",
                "~/Content/MediaQueries(width-240 and less).css", 
                "~/Content/MediaQueries(width-320).css",
                "~/Content/MediaQueries(width-360).css",
                "~/Content/MediaQueries(width-480).css",
                "~/Content/MediaQueries(width-568).css",
                "~/Content/MediaQueries(width-640).css",
                "~/Content/MediaQueries(width-720).css",
                "~/Content/MediaQueries(width-800).css",
                "~/Content/MediaQueries(width-960).css",
                "~/Content/MediaQueries(width-1024).css",
                "~/Content/MediaQueries(width-1150).css"

                ));

        }
    }
}