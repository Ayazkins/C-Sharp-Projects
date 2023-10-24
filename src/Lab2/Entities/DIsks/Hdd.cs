namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.DIsks;

public class Hdd : DetailBase
{
    public Hdd(string name, int capacity, int speed, int energyConsumption)
        : base(name)
    {
        Capacity = capacity;
        Speed = speed;
        EnergyConsumption = energyConsumption;
    }

    public int Capacity { get; set; }
    public int Speed { get; set; }
    public int EnergyConsumption { get; set; }
}