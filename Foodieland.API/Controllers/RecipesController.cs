using Microsoft.AspNetCore.Mvc;

namespace Foodieland.API.Controllers;

[Route("[controller]")]
public class RecipesController : ApiController
{
    [HttpGet]
    public IActionResult ListRecipes()
    {
        return Ok(Array.Empty<string>());
    }
}