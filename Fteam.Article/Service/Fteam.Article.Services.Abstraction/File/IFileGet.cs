namespace Fteam.Article.Services.Abstraction;

public interface IFileGet : IAsyncDisposable
{
    Task<IEnumerable<Attachment>> GetFilesAsync(Guid objectId, byte type);

    Task<IEnumerable<Attachment>> GetFilesAsync(Guid objectId);

    Task<Attachment?> FindFileAsync(Guid obejctId, byte type);
}
