using Foodieland.Contracts.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace Foodieland.API.Controllers;

[Route("[controller]")]
public class RecipesController : ApiController
{
    [HttpPost]
    public IActionResult CreateRecipe(CreateRecipeRequest request)
    {
        return Ok(request);
    }
}