using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using VedaYOU.Core.Interfaces;

namespace VedaYOU.Controllers
{
    public class VedayouController : RenderMvcController
    {
        private readonly IPageService pageService;

        public VedayouController(IPageService pageService)
        {
            this.pageService = pageService;
        }

        public override ActionResult Index(RenderModel model)
        {
            var vedayouPage = pageService.GetRootPage();

            return View(vedayouPage);
        }        
    }
}