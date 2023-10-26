using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPUFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SocketFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class CpuAndCoolerValidator : IValidator
{
    private readonly string _faultMessage = "Cpu and cooler have different sockets\n";
    private readonly string _noGuaranteeMessage = "Tdp not enough\n";

    public ValidatorResult Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (!CheckSockets(computer.Cpu, computer.Cooler))
        {
            return new ValidatorResult.Fault(_faultMessage);
        }

        if (!CheckTdp(computer.Cpu, computer.Cooler))
        {
            return new ValidatorResult.NoGuarantee(_noGuaranteeMessage);
        }

        return new ValidatorResult.SuccessResult();
    }

    private bool CheckSockets(Cpu cpu, Cooler cooler)
    {
        foreach (Socket socket in cooler.SupportedSockets)
        {
            if (cpu.Socket.Name == socket.Name)
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckTdp(Cpu cpu, Cooler cooler)
    {
        if (cooler.TDP > cpu.Tdp)
        {
            return true;
        }

        return false;
    }
}