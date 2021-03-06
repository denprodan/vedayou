﻿using System;
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
using IMediaService = VedaYOU.Core.Interfaces.IMediaService;

namespace VedaYOU.Core.Services
{
    public class PageService : IPageService
    {
        private readonly IAppSiteContext _appSiteContext;
        private readonly UmbracoHelper _umbracoHelper;
        private readonly IMediaService _mediaService;

        public PageService(IAppSiteContext appSiteContext, UmbracoHelper umbracoHelper, IMediaService mediaService)
        {
            _appSiteContext = appSiteContext;
            _umbracoHelper = umbracoHelper;
            _mediaService = mediaService;
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

            var articlesPage =
                content.FirstChild(
                    publishedContent => publishedContent.DocumentTypeAlias == GlobalConstants.ArticlesPage);

            if (articlesPage == null)
            {
                throw (new Exception("Document page ArticlesPage not found"));
            }

            var articleContents =
                    articlesPage.Children<IPublishedContent>()
                        .Where(el => el.DocumentTypeAlias == GlobalConstants.ArticleAlias).ToList();

            var articlesPages = articleContents.Select(ac => MapArticlePage(ac)).ToList();

            if (orderByDate)
            {
                return articlesPages.OrderByDescending(article => article.CreateDate);
            }

            return articlesPages;


        }

        public Article GetArticle(int id)
        {
            var rootPage = GetRootPage();

            var content = GetRootPageContent(rootPage.Id);

            var articlesPage =
                content.FirstChild(
                    publishedContent => publishedContent.DocumentTypeAlias == GlobalConstants.ArticlesPage);

            if (articlesPage == null)
            {
                throw (new Exception("Document page ArticlesPage not found"));

            }

            var articleContent =
                    articlesPage.Children<IPublishedContent>()
                        .FirstOrDefault(el => el.DocumentTypeAlias == GlobalConstants.ArticleAlias && el.Id == id);

            var articlePage = MapArticlePage(articleContent);

            return articlePage;

        }

        public IPublishedContent GetPublishedContent(int id)
        {
            try
            {
                return _umbracoHelper.TypedContent(id);
            }
            catch (Exception exception)
            {
                throw (exception);
            }
        }

        private Vedayou MapVedayouPage(IPublishedContent content)
        {
            var vedayouPage = new Vedayou
            {
                Id = content.Id,
                MetaKeywords = content.GetPropertyValue<Vedayou, string>(page => page.MetaKeywords),
                MetaDescription = content.GetPropertyValue<Vedayou, string>(page => page.MetaDescription),
                MetaTitle = content.GetPropertyValue<Vedayou, string>(page => page.MetaTitle),
            };
            return vedayouPage;
        }

        private Article MapArticlePage(IPublishedContent content)
        {
            var articlePage = new Article
            {
                Id = content.Id,
                Url = umbraco.library.NiceUrl(content.Id),
                Body = content.GetPropertyValue<Article, string>(article => article.Body),
                Title = content.GetPropertyValue<Article, string>(article => article.Title),
                HeaderImage = _mediaService.GetMediaPathById(content.GetPropertyValue<Article, string>(article => article.HeaderImage)),
                Icon = _mediaService.GetMediaPathById(content.GetPropertyValue<Article, string>(article => article.Icon)),
                UseMainImage = content.GetPropertyValue<Article, bool>(article => article.UseMainImage),
                CreateDate = content.CreateDate,
                MetaKeywords = content.GetPropertyValue<Article, string>(article => article.MetaKeywords),
                MetaDescription = content.GetPropertyValue<Article, string>(article => article.MetaDescription),
                MetaTitle = content.GetPropertyValue<Article, string>(article => article.MetaTitle)
            };
            return articlePage;
        }
    }
}