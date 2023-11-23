using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record CommandContext(Command Iterator, IFileSystem FileSystem);