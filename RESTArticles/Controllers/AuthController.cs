using Microsoft.AspNetCore.Mvc;
using RESTArticlesLibrary.Interfaces.Services;

namespace RESTArticles.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public ActionResult<string> GenerateToken()
    {
        var result = _authService.GenerateToken();

        return result;
    }
}
