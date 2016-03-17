using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace VedaYOU.Controllers
{
    public class VedayouController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            return View();
        }        
    }
}