using Foodieland.Domain.Common.Models;
using Foodieland.Domain.Ingredient.ValueObjects;

namespace Foodieland.Domain.Ingredient;

public sealed class Ingredient : AggregateRoot<IngredientId>
{
    public string Name { get; }
    
    private Ingredient(IngredientId id, string name) : base(id)
    {
        Name = name;
    }

    public static Ingredient Create(IngredientId id, string name)
    {
        return new Ingredient(IngredientId.CreateUnique(), name);
    }
}