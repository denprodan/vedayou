using System.Collections.Generic;
using VedaYOU.Persistence.DocumentTypes;

namespace VedaYOU.Core.Interfaces
{
    public interface IPageService
    {
        Vedayou GetRootPage();

        IEnumerable<Article> GetAllArticles(bool orderByDate = false);

        Article GetArticle(int id);

    }
}
