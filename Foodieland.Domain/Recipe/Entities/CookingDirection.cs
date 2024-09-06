using Foodieland.Domain.Common.Models;
using Foodieland.Domain.Recipe.ValueObjects;

namespace Foodieland.Domain.Recipe.Entities;

public sealed class CookingDirection : Entity<CookingDirectionId>
{
    public int StepNumber { get; }
    
    public string Name { get; }

    public string Description { get; }
    
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
}