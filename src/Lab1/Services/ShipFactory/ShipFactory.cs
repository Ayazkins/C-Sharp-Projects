using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactory;

public abstract class ShipFactory
{
    public abstract bool Nithrin();
    public abstract DeflectorBase CreateDeflector(bool add = false);
    public abstract EngineBase CreateEngine();
    public abstract JumpEngineBase CreateJumpEngine();
    public abstract ShellBase CreateShell();

    public abstract string GiveName();
}