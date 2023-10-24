using Fteam.Article.DataBase.Entitiy;
using Microsoft.EntityFrameworkCore;

namespace Fteam.Article.DataBase.Context;

public class ArticleContext : DbContext
{
    public static string ConnectionString { get; set; }

    public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
    { }

    public ArticleContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(ConnectionString);
    }

    public virtual DbSet<Entitiy.Article> Article { get; set; }

    public virtual DbSet<Group> Group { get; set; }

    public virtual DbSet<ArticlesGroups> ArticlesGroups { get; set; }

    public virtual DbSet<ArticlesKeywords> ArticlesKeywords { get; set; }

    public virtual DbSet<Keyword> Keyword { get; set; }

    public virtual DbSet<Attachment> Attachment { get; set; }
}
