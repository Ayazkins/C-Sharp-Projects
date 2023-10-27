using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponents;

public class JedecAndVoltage
{
    public JedecAndVoltage(int jedec, int voltage)
    {
        if (JEDEC <= 0)
        {
            throw new NotPositiveValue(nameof(JEDEC));
        }

        if (voltage <= 0)
        {
            throw new NotPositiveValue(nameof(voltage));
        }

        JEDEC = jedec;
        Voltage = voltage;
    }

    public int JEDEC { get; set; }
    public int Voltage { get; set; }
}