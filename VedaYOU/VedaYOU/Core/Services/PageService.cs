using System;
using System.Collections.Generic;
using System.Linq;
using umbraco.cms.businesslogic.web;
using Umbraco.Core.Models;
using Umbraco.Web;
using VedaYOU.Core.Interfaces;
using VedaYOU.Entities;
using VedaYOU.Persistence.DocumentTypes;
using VedaYOU.Infrastructure;
using VedaYOU.Infrastructure.Extensions;

namespace VedaYOU.Core.Services
{
    public class PageService : IPageService
    {
        private readonly IAppSiteContext _appSiteContext;
        private readonly UmbracoHelper _umbracoHelper;

        public PageService(IAppSiteContext appSiteContext, UmbracoHelper umbracoHelper)
        {
            _appSiteContext = appSiteContext;
            _umbracoHelper = umbracoHelper;
        }

        public Vedayou GetRootPage()
        {
            var content = _umbracoHelper.TypedContentAtRoot();

            var currentDomain = _appSiteContext.GetCurrentDomain();


            var vedayouContent = content.FirstOrDefault(
                publishedContent =>
                    Domain.GetDomainsById(publishedContent.Id).Any(domain => domain.Id == currentDomain.Id));

            return MapVedayouPage(vedayouContent);
        }

        public IPublishedContent GetRootPageContent(int rootPageId)
        {
            return GetPublishedContent(rootPageId);
        }

        public IEnumerable<Article> GetAllArticles(bool orderByDate)
        {
            var rootPage = GetRootPage();

            var content = GetRootPageContent(rootPage.Id);

            var articlePageFolder =
                content.FirstChild(
                    publishedContent => publishedContent.DocumentTypeAlias == GlobalConstants.ArticlesFolderAlias);

            if (articlePageFolder != null)
            {

                var articleContents =
                    articlePageFolder.Children<IPublishedContent>()
                        .Where(el => el.DocumentTypeAlias == GlobalConstants.ArticleAlias).ToList();

                var articlesPages = articleContents.Select(ac => MapArticlePage(ac)).ToList();

                if (orderByDate)
                {
                    return articlesPages.OrderByDescending(article => article.CreateDate);
                }

                return articlesPages;
            }

            return Enumerable.Empty<Article>();
        }

        public Article GetArticle(int id)
        {
            throw new System.NotImplementedException();
        }

        public IPublishedContent GetPublishedContent(int id)
        {
            try
            {
                return _umbracoHelper.TypedContent(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Vedayou MapVedayouPage(IPublishedContent content)
        {
            var vedayouPage = new Vedayou { Id = content.Id };
            return vedayouPage;
        }

        private Article MapArticlePage(IPublishedContent content)
        {
            var articlePage = new Article
            {
                Id = content.Id,
                Body = content.GetPropertyValue<Article, string>(article => article.Body),
                Title = content.GetPropertyValue<Article, string>(article => article.Title),
                HeaderImage = content.GetPropertyValue<Article, string>(article => article.HeaderImage),
                Icon = content.GetPropertyValue<Article, string>(article => article.Icon),
                CreateDate = content.CreateDate
            };
            return articlePage;
        }
    }
}