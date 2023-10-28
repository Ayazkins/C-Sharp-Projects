using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIskComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class PcieValidator : IValidator
{
    private readonly string _videoCardFault = "No pcie for graphic gard\n";
    private readonly string _wifiFault = "No pcie for wifi\n";
    private readonly string _ssdFault = "No pcie for ssd\n";

    public ValidatorResult Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        IOrderedEnumerable<Pcie> sorted =
            from p in computer.Motherboard.Pcies orderby p.Pins select p;
        if (computer.Videocard != null && !CheckVideoCard(sorted, computer.Videocard))
        {
            return new ValidatorResult.Fault(_videoCardFault);
        }

        if (computer.WiFi != null && !CheckWiFI(sorted, computer.WiFi))
        {
            return new ValidatorResult.Fault(_wifiFault);
        }

        if (!CheckSsd(sorted, computer.Disks))
        {
            return new ValidatorResult.Fault(_ssdFault);
        }

        return new ValidatorResult.SuccessResult();
    }

    private bool CheckVideoCard(IOrderedEnumerable<Pcie> sorted, Videocard videocard)
    {
        foreach (Pcie pcie in sorted)
        {
            if (videocard.Pcie.Pins <= pcie.Pins && !pcie.Used)
            {
                pcie.Used = true;
                return true;
            }
        }

        return false;
    }

    private bool CheckWiFI(IOrderedEnumerable<Pcie> sorted, WiFi wiFi)
    {
        foreach (Pcie pcie in sorted)
        {
            if (wiFi.Pcie.Pins <= pcie.Pins && !pcie.Used)
            {
                pcie.Used = true;
                return true;
            }
        }

        return false;
    }

    private bool CheckSsd(IOrderedEnumerable<Pcie> sorted, IReadOnlyCollection<Disk> ssds)
    {
        var ssdDisk = new List<Disk>();
        foreach (Disk disk in ssds)
        {
            if (disk.Pcie != null)
            {
                ssdDisk.Add(disk);
            }
        }

        foreach (Disk ssd in ssdDisk)
        {
            if (ssd.Pcie == null)
            {
                continue;
            }

            bool found = false;
            foreach (Pcie pcie in sorted)
            {
                if (ssd.Pcie != null && ssd.Pcie.Pins <= pcie.Pins && !pcie.Used)
                {
                    pcie.Used = true;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return false;
            }
        }

        return true;
    }
}