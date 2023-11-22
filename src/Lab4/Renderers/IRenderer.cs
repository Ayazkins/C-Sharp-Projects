using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderers;

public interface IRenderer
{
    public void RenderTree(ITree tree, string folder, string file, string space);

    public void RenderTree(ITree tree);

    public void RenderMessage(string message);
}