using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTArticlesLibrary.DTOs;
using RESTArticlesLibrary.Exceptions;
using RESTArticlesLibrary.Interfaces.Services;

namespace RESTArticles.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticlesController : ControllerBase
{
    private readonly IArticleService _articleService;

    public ArticlesController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ArticleDTO>> AddArticle(ArticleDTO request)
    {
        var result = await _articleService.AddArticle(request.Title, request.Content);
        if (result.IsSuccess)
            return CreatedAtAction(nameof(GetArticle), new { id = result.Result!.Id }, result.Result!);

        if (result.Error is TextTooLongException || result.Error is ArgumentNullException)
            return BadRequest(result.Error.Message);
        return StatusCode(500);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArticleDTO>>> GetArticles(int pageNumber = 1, int pageSize = 10)
    {
        var result = await _articleService.GetArticles(pageNumber, pageSize);
        if (result.IsSuccess)
            return Ok(result.Result!);

        return StatusCode(500);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ArticleDTO>> GetArticle(int id)
    {
        var result = await _articleService.GetArticleById(id);
        if (result.IsSuccess)
            return result.Result!;

        if (result.Error is ArticleNotFoundException)
            return NotFound();
        return StatusCode(500);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var result = await _articleService.RemoveArticle(id);
        if (result.IsSuccess)
            return NoContent();

        if (result.Error is ArticleNotFoundException)
            return NotFound();
        return StatusCode(500);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<ArticleDTO>> UpdateArticle(int id, ArticleDTO request)
    {
        var result = await _articleService.UpdateArticle(id, request.Title, request.Content);
        if (result.IsSuccess)
            return result.Result!;

        if (result.Error is ArticleNotFoundException)
            return NotFound();
        if (result.Error is TextTooLongException || result.Error is ArgumentNullException)
            return BadRequest(result.Error.Message);
        return StatusCode(500);
    }
}
