using ErrorOr;

namespace Foodieland.Domain.Common.Errors;

public static partial class Errors
{
    public static class Recipe
    {
        public static Error NotFound => Error.NotFound(
            code: "Recipe.NotFound",
            description: "Recipe not found or doesn't exist");
        
        public static Error Unauthorized => Error.Unauthorized(
            code: "Recipe.Unauthorized",
            description: "You are not authorized to modify this recipe");
    }
}