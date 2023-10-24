namespace Fteam.Article.DataBase.Entitiy;

public record Attachment : BaseEntity
{
    [Required]
    public Guid FileId { get; set; }

    [Required]
    public string FileToken { get; set; }

    [Required]
    public Guid ObjectId { get; set; }

    [Required]
    public int Placement { get; set; }
}
