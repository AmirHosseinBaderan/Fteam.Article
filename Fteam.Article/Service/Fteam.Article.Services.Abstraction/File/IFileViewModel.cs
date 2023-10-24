namespace Fteam.Article.Services.Abstraction;

public interface IFileViewModel
{
    FileViewModel CreateFileViewModel(Attachment attachment);

    IEnumerable<FileViewModel>? CreateFileViewModel(IEnumerable<Attachment> attachments);
}
