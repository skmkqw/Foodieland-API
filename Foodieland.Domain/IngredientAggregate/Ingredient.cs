using Foodieland.Domain.Common.Models;
using Foodieland.Domain.IngredientAggregate.ValueObjects;

namespace Foodieland.Domain.IngredientAggregate;

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