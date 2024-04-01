using RESTArticlesLibrary.DTOs;
using RESTArticlesLibrary.Infrastructure;

namespace RESTArticlesLibrary.Interfaces.Services;

public interface IArticleService : IDisposable
{
    Task<ServiceResult<ArticleDTO>> AddArticle(string title, string content);
    Task<ServiceResult<ArticleDTO>> GetArticleById(int id);
    Task<ServiceResult<IEnumerable<ArticleDTO>>> GetArticles(int pageNumber, int pageSize);
    Task<ServiceResult<ArticleDTO>> UpdateArticle(int id, string title, string content);
    Task<ServiceResult<ArticleDTO>> RemoveArticle(int id);
}
