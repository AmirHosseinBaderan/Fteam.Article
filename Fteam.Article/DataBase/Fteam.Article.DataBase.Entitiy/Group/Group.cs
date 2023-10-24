
namespace Fteam.Article.DataBase.Entitiy;

public record Group : BaseEntity
{
    [Required]
    public string Name { get; set; }

    // Navigation Properties
    // Relationships

    public virtual ICollection<ArticlesGroups> ArticlesGroups { get; set; }
}
