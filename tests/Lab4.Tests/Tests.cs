using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    private readonly IParser _parser;
    private ITree? _tree;

    public Tests()
    {
        _parser = new ConnectLocalParser();
        var connectInMemoryParser = new ConnectInMemoryParser();
        var disconnectParser = new DisconnectParser();
        var treeGotoParser = new TreeGotoParser();
        var treeListParser = new TreeListParser();
        var fileShowParser = new FileShowConcoleParser();
        var fileMoveParser = new FileMoveParser();
        var fileCopyParser = new FileCopyParser();
        var fileDeleteParser = new FileDeleteParser();
        var fileRenameParser = new FileRenameParser();
        _parser.Successor = connectInMemoryParser;
        connectInMemoryParser.Successor = disconnectParser;
        disconnectParser.Successor = treeGotoParser;
        treeGotoParser.Successor = treeListParser;
        treeListParser.Successor = fileShowParser;
        fileShowParser.Successor = fileMoveParser;
        fileMoveParser.Successor = fileCopyParser;
        fileCopyParser.Successor = fileDeleteParser;
        fileDeleteParser.Successor = fileRenameParser;
        IDirectory root = new Directory("/home", null);
        root.AddDirectory(new Directory("/home/test", root));
        root.Directories[0].AddFile(new InMemoryFIle("/home/test/file.txt", root.Directories[0]));
        root.AddDirectory(new Directory("/home/test2", root));
        root.AddDirectory(new Directory("/home/test3", root));
        root.AddDirectory(new Directory("/home/test4", root));
        root.AddDirectory(new Directory("/home/test5", root));
        _tree = new InMemoryTree(root);
    }

    [Fact]
    public void ParserTest()
    {
        string[] args = new string[] { "connect", "/home", "-m", "inmemory" };
        Assert.IsType<ConnectInMemoryCommand>(_parser.Parse(args));
        args = new string[] { "disconnect" };
        Assert.IsType<DisconnectCommand>(_parser.Parse(args));
        args = new string[] { "tree", "goto", "/path/to/directory" };
        Assert.IsType<TreeGotoCommand>(_parser.Parse(args));

        args = new string[] { "tree", "list", "-d", "2" };
        Assert.IsType<TreeListCommand>(_parser.Parse(args));

        args = new string[] { "file", "show", "/path/to/file", "-m", "console" };
        Assert.IsType<FileShowConsoleCommand>(_parser.Parse(args));

        args = new string[] { "file", "move", "/path/to/source", "/path/to/destination" };
        Assert.IsType<FileMoveCommand>(_parser.Parse(args));

        args = new string[] { "file", "copy", "/path/to/source", "/path/to/destination" };
        Assert.IsType<FileCopyCommand>(_parser.Parse(args));

        args = new string[] { "file", "delete", "/path/to/file" };
        Assert.IsType<FileDeleteCommand>(_parser.Parse(args));

        args = new string[] { "file", "rename", "/path/to/file", "newname" };
        Assert.IsType<FileRenameCommand>(_parser.Parse(args));
    }

    [Fact]
    public void CommandExecutionTest()
    {
        string[] args = new string[] { "tree", "goto", "/home/test" };
        _tree = _parser.Parse(args).Execute(_tree);
        Assert.NotNull(_tree);
        Assert.Equal("/home/test", _tree.Current.DirectoryPath);

        args = new string[] { "file", "move", "/home/test/file.txt", "/home/test2" };
        _tree = _parser.Parse(args).Execute(_tree);
        Assert.NotNull(_tree);
        Assert.NotNull(_tree.GetFile("/home/test2/file.txt"));
        Assert.Throws<ArgumentException>(() => _tree.GetFile("/home/test/file.txt"));

        args = new string[] { "file", "copy", "/home/test2/file.txt", "/home/test" };
        _tree = _parser.Parse(args).Execute(_tree);
        Assert.NotNull(_tree);
        Assert.NotNull(_tree.GetFile("/home/test2/file.txt"));
        Assert.NotNull(_tree.GetFile("/home/test/file.txt"));

        args = new string[] { "file", "delete", "/home/test2/file.txt" };
        _tree = _parser.Parse(args).Execute(_tree);
        Assert.NotNull(_tree);
        Assert.Throws<ArgumentException>(() => _tree.GetFile("/home/test2/file.txt"));

        args = new string[] { "file", "rename", "/home/test/file.txt", "hello" };
        _tree = _parser.Parse(args).Execute(_tree);
        Assert.NotNull(_tree);
        Assert.Throws<ArgumentException>(() => _tree.GetFile("/home/test/file.txt"));
        Assert.NotNull(_tree.GetFile("/home/test/hello"));
    }
}