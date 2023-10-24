namespace Fteam.Article.Services.Implementation;

internal class FileGet : IFileGet
{
    private readonly IBaseQuery<Attachment> _attacmentQuery;

    public FileGet(IBaseQuery<Attachment> attacmentQuery)
    {
        _attacmentQuery = attacmentQuery;
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        await _attacmentQuery.DisposeAsync();
    }

    public async Task<Attachment?> FindFileAsync(Guid obejctId, byte type)
        => await _attacmentQuery.GetAsync(f => f.ObjectId == obejctId && f.Type == type);

    public async Task<IEnumerable<Attachment>> GetFilesAsync(Guid objectId, byte type)
        => await _attacmentQuery.GetAllAsync(a => a.ObjectId == objectId && (type == 0 || a.Type == type));

    public async Task<IEnumerable<Attachment>> GetFilesAsync(Guid objectId)
        => await _attacmentQuery.GetAllAsync(a => a.ObjectId == objectId, a => a.CreateDate);
}
