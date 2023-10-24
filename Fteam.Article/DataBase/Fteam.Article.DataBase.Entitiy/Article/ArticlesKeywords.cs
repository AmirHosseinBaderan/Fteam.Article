namespace Fteam.Article.DataBase.Entitiy;

public record ArticlesKeywords : BaseEntity
{
    [Required]
    public Guid ArticleId { get; set; }

    [Required]
    public Guid KeywordId { get; set; }

    // Navigation Properties
    // Relationships

    public virtual Article Article { get; set; }

    public virtual Keyword Keyword { get; set; }
}
