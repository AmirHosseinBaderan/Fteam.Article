namespace Fteam.Article.DataBase.Entitiy;

public record Keyword : BaseEntity
{
    [Required]
    public string Key { get; set; }

    // Navigation Properties
    // Relationships

    public virtual ICollection<ArticlesKeywords> ArticlesKeywords { get; set; }
}
