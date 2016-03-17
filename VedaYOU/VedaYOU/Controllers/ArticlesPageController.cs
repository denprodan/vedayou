using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using VedaYOU.Core.Interfaces;
using VedaYOU.Infrastructure.Extensions;
using VedaYOU.Models;

namespace VedaYOU.Controllers
{
    public class ArticlesPageController : RenderMvcController
    {
        private readonly IPageService _pageService;

        public ArticlesPageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        public override ActionResult Index(RenderModel model)
        {
            var articles = _pageService.GetAllArticles(true);

            return View(articles.Map<IEnumerable<ArticleViewModel>>());
        }
    }
}