using IPM.Application.IUtils;

namespace IPM.WebApi.Utils;

public sealed class FormFileProxy: IFile
{
    private readonly IFormFile _formFile;

    public string ContentType => _formFile.ContentType;

    public long Length => _formFile.Length;

    public string FileName => _formFile.FileName;

    public FormFileProxy(IFormFile formFile)
    {
        _formFile = formFile;
    }

    public Task CopyToAsync(Stream target) 
    {
        return _formFile.CopyToAsync(target);
    }
}
