using System;
using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFyleSystem : IFileSystem
{
    private string? _path;
    public IFileSystem Connect(string path)
    {
        if (Directory.Exists(path))
        {
            _path = path;
            Console.WriteLine("Success");
        }
        else
        {
            Console.WriteLine("Invalid path");
        }

        return this;
    }

    public IFileSystem Disconnect()
    {
        _path = null;
        return this;
    }

    public void ChangeDirectory(string path)
    {
        if (path is null) return;
        if (IsAbsolutPath(path))
        {
            _path = path;
            Console.WriteLine($"Directory changed to {_path}");
        }
        else
        {
            string curPath = _path + '\\' + path;

            if (Directory.Exists(curPath))
            {
                _path = curPath;
                Console.WriteLine($"Directory changed to {_path}");
            }
            else
            {
                Console.WriteLine("Invalid Path");
            }
        }
    }

    public void ListFiles(int depth, int curDepth, string? path)
    {
        if (path is null) path = _path;
        if (path is null)
        {
            Console.WriteLine("Connect first");
            return;
        }

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Invalid Path");
        }

        foreach (string? directory in Directory.GetDirectories(path))
        {
            string shift = string.Concat(Enumerable.Repeat('\t', curDepth));
            Console.WriteLine(shift + directory);
            if (depth != curDepth + 1)
            {
                ListFiles(depth, curDepth + 1, directory);
            }
        }
    }

    public void OpenFile(string filename)
    {
        string fileContains = File.ReadAllText(_path + '\\' + filename);

        Console.WriteLine(fileContains);
    }

    public void MoveFile(string firstPath, string secondPath)
    {
        string from = CreateAbsolutePath(firstPath);

        string to = CreateAbsolutePath(secondPath);

        if (!File.Exists(from) || File.Exists(to))
        {
            Console.WriteLine("Invalid path");
            return;
        }

        File.Move(from, to + '\\' + Path.GetFileName(from));
    }

    public void CopyFile(string firstPath, string secondPath)
    {
        string from = CreateAbsolutePath(firstPath);

        string to = CreateAbsolutePath(secondPath);

        if (!File.Exists(from) || File.Exists(to))
        {
            Console.WriteLine("Invalid path");
            return;
        }

        File.Copy(from, to + '\\' + Path.GetFileName(from));
    }

    public void DeleteFile(string path)
    {
        string curFile = CreateAbsolutePath(path);

        if (File.Exists(curFile))
        {
            File.Delete(curFile);
        }
        else
        {
            Console.WriteLine("Invalid Path");
        }
    }

    public void RenameFile(string path, string name)
    {
        if (path is null)
        {
            Console.WriteLine("Invalid arguments");
            return;
        }

        string from = CreateAbsolutePath(path);

        int i = path.Length - 1;
        while (from[i] != '\\')
        {
            i--;
        }

        string to = string.Concat(from.AsSpan(0, i), '\\' + name);

        Console.WriteLine(to);
        if (!File.Exists(from))
        {
            Console.WriteLine("Invalid path");
        }

        File.Move(from, to);
    }

    private static bool IsAbsolutPath(string path)
    {
        if (path is null || path.Length < 2) return false;

        return path[1] == ':';
    }

    private string CreateAbsolutePath(string path)
    {
        string result = path;
        if (!IsAbsolutPath(result))
        {
            result = _path + '\\' + path;
        }

        return result;
    }
}