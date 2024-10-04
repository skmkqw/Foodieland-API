using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodieland.Infrastructure.Persistence.Configurations;

public class ReviewConfigurations : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");
        
        //PK
        builder.HasKey(x => x.Id);
        
        //Id
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ReviewId.Create(value));
        
        //CreatorId
        builder.Property(x => x.CreatorId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
        
        //RecipeId
        builder.Property(x => x.RecipeId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => RecipeId.Create(value));
        
        //Content
        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(1000);
        
        //Rating

        builder.Property(x => x.Rating)
            .IsRequired();
    }
}