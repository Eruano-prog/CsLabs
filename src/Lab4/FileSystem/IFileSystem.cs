namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    public IFileSystem Connect(string path);
    public IFileSystem Disconnect();
    public void ChangeDirectory(string path);
    public void ListFiles();
    public void OpenFile(string filename);
    public void MoveFile(string firstPath, string secondPath);
    public void CopyFile(string firstPath, string secondPath);
    public void DeleteFile(string path);
    public void RenameFile(string path, string name);
}