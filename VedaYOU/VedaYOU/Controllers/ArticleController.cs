using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using VedaYOU.Core.Interfaces;
using VedaYOU.Infrastructure.Extensions;
using VedaYOU.Models;

namespace VedaYOU.Controllers
{
    public class ArticleController : RenderMvcController
    {
        private readonly IPageService _pageService;

        public ArticleController(IPageService pageService)
        {
            _pageService = pageService;
        }

        public override ActionResult Index(RenderModel model)
        {
            var article = _pageService.GetArticle(model.Content.Id);            
            if (article != null)
            {
                var articleViewModel = article.Map<ArticleViewModel>();

                return View(articleViewModel);
            }
            //add error page
            return null;

        }
    }
}