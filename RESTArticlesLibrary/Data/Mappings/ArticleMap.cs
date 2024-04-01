using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTArticlesLibrary.Entities;

namespace RESTArticlesLibrary.Data.Mappings;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");

        builder.HasKey("Id");

        builder.Property(p => p.Title)
            .HasColumnType($"varchar({Article.TitleMaxLength})")
            .IsRequired();

        builder.Property(p => p.Content)
            .HasColumnType($"varchar({Article.ContentMaxLength})")
            .IsRequired();

        builder.Property(p => p.PublishedDate)
            .HasColumnType("TEXT")
            .IsRequired();
    }
}
