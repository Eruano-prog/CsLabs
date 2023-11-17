using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Test
{
    [Fact]
    public void Test1()
    {
        var com = new Command("First Second");
        Assert.Equal("First", com.Current);
        com.MoveNext();
        Assert.Equal("Second", com.Current);
    }
}