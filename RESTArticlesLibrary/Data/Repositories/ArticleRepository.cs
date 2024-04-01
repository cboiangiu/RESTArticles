using RESTArticlesLibrary.Data.Context;
using RESTArticlesLibrary.Entities;
using RESTArticlesLibrary.Interfaces.Repositories;

namespace RESTArticlesLibrary.Data.Repositories;

public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    public ArticleRepository(RESTArticlesDBContext context)
        : base(context) { }
}
