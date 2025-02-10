namespace IPM.Application.IUtils;

public interface IFile
{
    string ContentType {get;}

    long Length {get;}

    string FileName {get;}

    Task CopyToAsync(Stream target);
}
