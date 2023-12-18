using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandInputs;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Renderers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class App
{
    private readonly IRenderer _renderer;
    private readonly IParser _parser;
    private readonly ICommandInput _commandInput;
    private ITree? _tree;

    public App(IRenderer renderer, IParser parser, ICommandInput commandInput)
    {
        _renderer = renderer;
        _commandInput = commandInput;
        _parser = parser;
        _tree = new InMemoryTree(new Directory(" ", null));
    }

    public void Run()
    {
        while (_tree != null)
        {
            string[]? input = _commandInput.GetCommand();
            if (input == null)
            {
                continue;
            }

            ICommand command;
            try
            {
                command = _parser.Parse(input);
            }
            catch (ArgumentException e)
            {
                _renderer.RenderMessage(e.Message);
                _renderer.RenderMessage("Try again");
                continue;
            }

            if (command is DisconnectCommand)
            {
                break;
            }

            try
            {
                _tree = command.Execute(_tree);
            }
            catch (ArgumentException e)
            {
                _renderer.RenderMessage(e.Message);
                _renderer.RenderMessage("Try again");
            }
        }
    }
}