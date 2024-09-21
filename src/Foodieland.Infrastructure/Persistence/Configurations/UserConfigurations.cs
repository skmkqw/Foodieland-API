using Foodieland.Domain.UserAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodieland.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
        ConfigureReviewIdsTable(builder);
        ConfigureRecipeIdsTable(builder);
        ConfigureLikedRecipeIdsTable(builder);
    }

    public void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        //PK
        builder.HasKey(x => x.Id);
        
        //ID
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
        
        //FirstName
        builder.Property(x => x.FirstName)
            .HasMaxLength(100);
        
        //LastName
        builder.Property(x => x.LastName)
            .HasMaxLength(200);
    }
    
    private void ConfigureReviewIdsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(r => r.ReviewIds, rib =>
        {
            rib.ToTable("ReviewIds");
            
            //FK
            rib.WithOwner().HasForeignKey("UserId");
            
            //PK
            rib.HasKey("Id");
            
            //ID
            rib.Property(d => d.Value)
                .ValueGeneratedNever()
                .HasColumnName("ReviewId");

        });
        
        builder.Metadata.FindNavigation(nameof(User.ReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    
    private void ConfigureRecipeIdsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(r => r.RecipeIds, rib =>
        {
            rib.ToTable("RecipeIds");
            
            //FK
            rib.WithOwner().HasForeignKey("UserId");
            
            //PK
            rib.HasKey("Id");
            
            //ID
            rib.Property(d => d.Value)
                .ValueGeneratedNever()
                .HasColumnName("RecipeId");

        });
        
        builder.Metadata.FindNavigation(nameof(User.RecipeIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    
    private void ConfigureLikedRecipeIdsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(r => r.RecipeIds, rib =>
        {
            rib.ToTable("LikedRecipeIds");
            
            //FK
            rib.WithOwner().HasForeignKey("UserId");
            
            //PK
            rib.HasKey("Id");
            
            //ID
            rib.Property(d => d.Value)
                .ValueGeneratedNever()
                .HasColumnName("RecipeId");

        });
        
        builder.Metadata.FindNavigation(nameof(User.LikedRecipes))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}