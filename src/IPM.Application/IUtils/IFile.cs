namespace IPM.Application.IUtils;

public interface IFile
{
    string ContentType { get; }

    long Length { get; }

    string FileName { get; }

    string FileNameWithoutExtension { get; }

    string Extension { get; }

    Task CopyToAsync(Stream target);
}
