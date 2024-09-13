using Foodieland.Domain.Common.Models;
using Foodieland.Domain.RecipeAggregate.ValueObjects;

namespace Foodieland.Domain.RecipeAggregate.Entities;

public sealed class CookingDirection : Entity<CookingDirectionId>
{
    public int StepNumber { get; private set; }
    
    public string Name { get; private set; }

    public string Description { get; private set; }
    
    private CookingDirection(CookingDirectionId id, int stepNumber, string name, string description) : base(id)
    {
        StepNumber = stepNumber;
        Name = name;
        Description = description;
    }

    public static CookingDirection Create(int stepNumber, string name, string description)
    {
        return new CookingDirection(CookingDirectionId.CreateUnique(), stepNumber, name, description);
    }
    
#pragma warning disable CS8618
    private CookingDirection()
#pragma warning restore CS8618
    {
    }
}