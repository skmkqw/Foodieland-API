using Foodieland.Domain.Common.Models;
using Foodieland.Domain.RecipeAggregate.ValueObjects;

namespace Foodieland.Domain.RecipeAggregate.Entities;

public class Ingredient : Entity<IngredientId>
{
    public string Name { get; private set; }
    
    public float Quantity { get; private set; }
    
    public string Unit { get; private set; }
    
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
    
#pragma warning disable CS8618
    private Ingredient()
#pragma warning restore CS8618
    {
    }
}