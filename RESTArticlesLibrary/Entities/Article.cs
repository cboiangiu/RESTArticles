using RESTArticlesLibrary.DTOs;
using RESTArticlesLibrary.Exceptions;

namespace RESTArticlesLibrary.Entities;

public class Article : BaseEntity
{
    private Article() { }

    public static Article Create()
    {
        var article = new Article { PublishedDate = DateTime.UtcNow };

        return article;
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title));

        if (title.Length > TitleMaxLength)
            throw new TextTooLongException(nameof(title), TitleMaxLength);

        Title = title;
    }

    public void SetContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentNullException(nameof(content));

        if (content.Length > ContentMaxLength)
            throw new TextTooLongException(nameof(content), ContentMaxLength);

        Content = content;
    }

    public string Title { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public DateTime PublishedDate { get; private set; }

    public const int TitleMaxLength = 60;
    public const int ContentMaxLength = 20000;

    public ArticleDTO ToModel() => new(Id, Title, Content, PublishedDate);
}
