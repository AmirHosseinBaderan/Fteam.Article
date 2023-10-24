namespace Fteam.Article.Services.Implementation;

internal class FileViewModelService : IFileViewModel
{
    public FileViewModel CreateFileViewModel(Attachment attachment)
        => new(Id: attachment.Id,
            ObjectId: attachment.ObjectId,
            FileId: attachment.FileId,
            FileToken: attachment.Token,
            Type: attachment.Type);

    public IEnumerable<FileViewModel>? CreateFileViewModel(IEnumerable<Attachment> attachments)
        => attachments.Any() ? attachments.Select(CreateFileViewModel) : null;
}
