using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Shell;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactory;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class ShipBase
{
    public ShipBase(ShipFactory? factory, bool photon = false)
    {
        if (factory == null)
        {
            throw new ArgumentNullException(nameof(factory));
        }

        Engine = factory.CreateEngine();
        JumpEngine = factory.CreateJumpEngine();
        Shell = factory.CreateShell();
        Deflector = factory.CreateDeflector(photon);
        AntiN = factory.Nithrin();
        IsCrewDead = false;
        Type = factory.GiveName();
    }

    public EngineBase Engine { get; }
    public JumpEngineBase JumpEngine { get; }
    public ShellBase Shell { get; }
    public DeflectorBase Deflector { get; }
    public string Type { get; }
    public bool IsCrewDead { get; private set; }

    public bool IsShipDead => !Shell.IsAlive;
    private bool AntiN { get; }

    public void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle is CosmoWhale && AntiN)
        {
            return;
        }

        Deflector.TakeDamage(obstacle);
        Shell.TakeDamage(obstacle);
        if (obstacle is AntiMateria && obstacle.IsAlive)
        {
            IsCrewDead = true;
        }
    }
}