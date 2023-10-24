using System.Linq.Expressions;

namespace Fteam.Article.Services.Abstraction;

public interface IFileAction : IAsyncDisposable
{
    Task<Attachment> AddFileAsync(FileViewModel file);

    Task<bool> DeleteFilesAsync(Expression<Func<Attachment, bool>> expression);
}
