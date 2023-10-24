namespace Fteam.Article.DataBase.Entitiy;

public record ArticlesGroups : BaseEntity
{
    [Required]
    public Guid GroupId { get; set; }

    [Required]
    public Guid ArticleId { get; set; }

    // Navigation Properties
    // Relationships

    public virtual Article Article { get; set; }

    public virtual Group Group { get; set; }
}
