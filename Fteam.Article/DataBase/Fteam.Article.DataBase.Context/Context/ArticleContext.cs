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
}
