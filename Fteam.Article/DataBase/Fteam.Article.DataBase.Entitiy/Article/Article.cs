namespace Fteam.Article.DataBase.Entitiy;

public record Article : BaseEntity
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string ShortDescription { get; set; }

    [Required]
    public string Text { get; set; }

    // Navigation Properties
    // Relationships

    public virtual ICollection<ArticlesGroups> ArticlesGroups { get; set; }

    public virtual ICollection<ArticlesKeywords> ArticlesKeywords { get; set; }
}
