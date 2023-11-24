using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderers;

public class ConsoleRenderer : IRenderer
{
    public ConsoleRenderer(IVisitor visitor)
    {
        Visitor = visitor;
    }

    public IVisitor Visitor { get; }

    public void RenderTree(ITree tree, string folder, string file, string space)
    {
        Visitor.Visit(tree, folder, file, space);
        RenderMessage(Visitor.Result);
    }

    public void RenderTree(ITree tree)
    {
        Visitor.Visit(tree, "*", ".", "  ");
        RenderMessage(Visitor.Result);
    }

    public void RenderMessage(string message)
    {
        Console.WriteLine(message);
    }
}