namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAMFolder;

public class JedecAndVoltage
{
    public JedecAndVoltage(int jedec, int voltage)
    {
        JEDEC = jedec;
        Voltage = voltage;
    }

    public int JEDEC { get; set; }
    public int Voltage { get; set; }
}