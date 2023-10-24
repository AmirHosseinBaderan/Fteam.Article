using System.ComponentModel.DataAnnotations;

namespace Fteam.Article.DataBase.Entitiy;

public record BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    public byte Status { get; set; }

    public DateTime? UpdateDate { get; set; }
}
