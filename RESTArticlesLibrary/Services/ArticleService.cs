using RESTArticlesLibrary.DTOs;
using RESTArticlesLibrary.Entities;
using RESTArticlesLibrary.Exceptions;
using RESTArticlesLibrary.Infrastructure;
using RESTArticlesLibrary.Interfaces.Repositories;
using RESTArticlesLibrary.Interfaces.Services;

namespace RESTArticlesLibrary.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<ServiceResult<ArticleDTO>> AddArticle(string title, string content)
    {
        var article = Article.Create();
        try
        {
            article.SetTitle(title);
            article.SetContent(content);
            await _articleRepository.Add(article);
            return ServiceResult.Success(article.ToModel());
        }
        catch (Exception e)
        {
            return ServiceResult.Fail<ArticleDTO>(e);
        }
    }

    public async Task<ServiceResult<IEnumerable<ArticleDTO>>> GetArticles(int pageNumber, int pageSize)
    {
        try
        {
            var articles = await _articleRepository.GetAll(pageNumber, pageSize, nameof(Article.PublishedDate));
            var articleDTOs = articles.Select(a => a.ToModel());
            return ServiceResult.Success(articleDTOs);
        }
        catch (Exception e)
        {
            return ServiceResult.Fail<IEnumerable<ArticleDTO>>(e);
        }
    }

    public async Task<ServiceResult<ArticleDTO>> GetArticleById(int id)
    {
        var article = await _articleRepository.GetById(id);

        return article != null
            ? ServiceResult.Success(article.ToModel())
            : ServiceResult.Fail<ArticleDTO>(new ArticleNotFoundException());
    }

    public async Task<ServiceResult<ArticleDTO>> RemoveArticle(int id)
    {
        var article = await _articleRepository.GetById(id);
        if (article == null)
            return ServiceResult.Fail<ArticleDTO>(new ArticleNotFoundException());

        try
        {
            await _articleRepository.Remove(article);
            return ServiceResult.Success(article.ToModel());
        }
        catch (Exception e)
        {
            return ServiceResult.Fail<ArticleDTO>(e);
        }
    }

    public async Task<ServiceResult<ArticleDTO>> UpdateArticle(int id, string title, string content)
    {
        var article = await _articleRepository.GetById(id);
        if (article == null)
            return ServiceResult.Fail<ArticleDTO>(new ArticleNotFoundException());

        try
        {
            article.SetTitle(title);
            article.SetContent(content);
            await _articleRepository.Update(article);
            return ServiceResult.Success(article.ToModel());
        }
        catch (Exception e)
        {
            return ServiceResult.Fail<ArticleDTO>(e);
        }
    }

    public void Dispose()
    {
        _articleRepository.Dispose();
    }
}
