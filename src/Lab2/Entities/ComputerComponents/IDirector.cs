namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;

public interface IDirector
{
   public Computer? ComputerConstruct(ComputerBuilder computerBuilder);
}