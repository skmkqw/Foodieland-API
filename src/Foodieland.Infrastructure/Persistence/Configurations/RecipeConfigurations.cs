using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodieland.Infrastructure.Persistence.Configurations;

public class RecipeConfigurations : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        ConfigureRecipesTable(builder);
        ConfigureCookingDirectionsTable(builder);
        ConfigureIngredientsTable(builder);
        ConfigureReviewIdsTable(builder);
    }

    private void ConfigureRecipesTable(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("Recipes");
        
        //PK
        builder.HasKey(r => r.Id);
        
        //ID
        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => RecipeId.Create(value));
        
        //Name
        builder.Property(r => r.Name)
            .HasMaxLength(100);
        
        //Description
        builder.Property(r => r.Description)
            .HasMaxLength(500);
        
        //NutritionInformation
        builder.OwnsOne(r => r.NutritionInformation);
        
        //CreatorID
        builder.Property(r => r.CreatorId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
        
        
    }
    
    private void ConfigureCookingDirectionsTable(EntityTypeBuilder<Recipe> builder)
    {
        builder.OwnsMany(r => r.Directions, db =>
        {
            db.ToTable("CookingDirections");
            
            //FK
            db.WithOwner().HasForeignKey("RecipeId");
            
            //PK
            db.HasKey("Id", "RecipeId", "StepNumber");
            
            //ID
            db.Property(d => d.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CookingDirectionId.Create(value));
            
            //Name
            db.Property(d => d.Name)
                .HasMaxLength(100);
            
            //Description
            db.Property(d => d.Description)
                .HasMaxLength(500);
        });
        
        builder.Metadata.FindNavigation(nameof(Recipe.Directions))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    
    private void ConfigureIngredientsTable(EntityTypeBuilder<Recipe> builder)
    {
        builder.OwnsMany(r => r.Ingredients, ib =>
        {
            ib.ToTable("Ingredients");
            
            //FK
            ib.WithOwner().HasForeignKey("RecipeId");
            
            //PK
            ib.HasKey("Id", "RecipeId");
            
            //ID
            ib.Property(i => i.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => IngredientId.Create(value));
            
            //Name
            ib.Property(i => i.Name)
                .HasMaxLength(100);
            
            ib.Property(i => i.Unit)
                .HasMaxLength(100);
        });
        
        builder.Metadata.FindNavigation(nameof(Recipe.Ingredients))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    
    private void ConfigureReviewIdsTable(EntityTypeBuilder<Recipe> builder)
    {
        builder.OwnsMany(r => r.ReviewIds, rib =>
        {
            rib.ToTable("ReviewIds");
            
            //FK
            rib.WithOwner().HasForeignKey("RecipeId");
            
            //PK
            rib.HasKey("Id");
            
            //ID
            rib.Property(d => d.Value)
                .ValueGeneratedNever()
                .HasColumnName("ReviewId");

        });
        
        builder.Metadata.FindNavigation(nameof(Recipe.ReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}