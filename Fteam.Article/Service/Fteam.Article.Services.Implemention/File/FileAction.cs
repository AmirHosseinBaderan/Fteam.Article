namespace Fteam.Article.Services.Implementation;

internal class FileAction : IFileAction
{
    private readonly IBaseQuery<Attachment> _attachmentQuery;

    private readonly IBaseCud<Attachment> _attachmentCud;

    public FileAction(IBaseQuery<Attachment> attachmentQuery, IBaseCud<Attachment> attachmentCud)
    {
        _attachmentQuery = attachmentQuery;
        _attachmentCud = attachmentCud;
    }

    public async Task<Attachment> AddFileAsync(FileViewModel file)
    {
        Attachment attachment = new()
        {
            FileId = file.FileId,
            ObjectId = file.ObjectId,
            Token = file.FileToken,
            Type = file.Type,
        };
        await _attachmentCud.InsertAsync(attachment);
        return attachment;
    }

    public async Task<bool> DeleteFilesAsync(Expression<Func<Attachment, bool>> expression)
            => await _attachmentCud.DeleteAsync(expression);

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        await _attachmentCud.DisposeAsync();
        await _attachmentQuery.DisposeAsync();
    }
}
