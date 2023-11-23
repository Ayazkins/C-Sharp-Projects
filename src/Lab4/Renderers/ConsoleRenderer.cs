using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderers;

public class ConsoleRenderer : IRenderer
{
    public void RenderTree(ITree tree, string folder, string file, string space)
    {
        IVisitor visitor = new Visitor(folder, file, space);
        visitor.Visit(tree);
        RenderMessage(visitor.Result);
    }

    public void RenderTree(ITree tree)
    {
        IVisitor visitor = new Visitor();
        visitor.Visit(tree);
        RenderMessage(visitor.Result);
    }

    public void RenderMessage(string message)
    {
        Console.WriteLine(message);
    }
}