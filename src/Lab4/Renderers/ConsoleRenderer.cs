using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderers;

public class ConsoleRenderer : IRenderer
{
    public void RenderTree(ITree tree, string folder, string file, string space)
    {
        RenderMessage(new Visitor(folder, file, space).Visit(tree));
    }

    public void RenderTree(ITree tree)
    {
        RenderMessage(new Visitor().Visit(tree));
    }

    public void RenderMessage(string message)
    {
        Console.WriteLine(message);
    }
}