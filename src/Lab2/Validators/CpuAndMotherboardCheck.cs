using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class CpuAndMotherboardCheck : IValidator
{
    private const string BiosFault = "Bios doesn't support cpu\n";
    private const string SocketFault = "Different cpu and motherboard sockets\n";

    public ValidatorResult Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        bool socketCheck = SocketCheck(computer.Cpu, computer.Motherboard);
        bool biosCheck = BiosCheck(computer.Cpu, computer.Motherboard);

        if (socketCheck && biosCheck)
        {
            return new ValidatorResult.SuccessResult();
        }

        if (socketCheck)
        {
            return new ValidatorResult.Fault(BiosFault);
        }

        if (biosCheck)
        {
            return new ValidatorResult.Fault(SocketFault);
        }

        return new ValidatorResult.Fault(SocketFault + BiosFault);
    }

    private bool SocketCheck(Cpu cpu, Motherboard motherboard)
    {
        return cpu.Socket.Name == motherboard.Socket.Name;
    }

    private bool BiosCheck(Cpu cpu, Motherboard motherboard)
    {
        foreach (Cpu goodCpu in motherboard.Bios.CpuList)
        {
            if (cpu.Name == goodCpu.Name)
            {
                return true;
            }
        }

        return false;
    }
}