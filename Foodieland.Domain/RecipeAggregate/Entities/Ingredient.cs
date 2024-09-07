using Foodieland.Domain.Common.Models;
using Foodieland.Domain.RecipeAggregate.ValueObjects;

namespace Foodieland.Domain.RecipeAggregate.Entities;

public class Ingredient : Entity<IngredientId>
{
    public string Name { get; }
    
    public float Quantity { get; }
    
    public string Unit { get; }
    
    private Ingredient(IngredientId id, string name, float quantity, string unit) : base(id)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }

    public static Ingredient Create(string name, float quantity, string unit)
    {
        return new Ingredient(IngredientId.CreateUnique(), name, quantity, unit);
    }
}