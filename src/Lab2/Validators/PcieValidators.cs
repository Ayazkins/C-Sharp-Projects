using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DIsks;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIEFolder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideocardFolder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class PcieValidators : IValidators
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

        if (!CheckSsd(sorted, computer.HddDisks))
        {
            return new ValidatorResult.Fault(_ssdFault);
        }

        return new ValidatorResult.SuccessResult();
    }

    private bool CheckVideoCard(IOrderedEnumerable<Entities.PCIEFolder.Pcie> sorted, Videocard videocard)
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

    private bool CheckSsd(IOrderedEnumerable<Pcie> sorted, IReadOnlyCollection<Hdd> ssds)
    {
        var ssdDisk = new List<Hdd>();
        foreach (Hdd disk in ssds)
        {
            if (disk is Ssd)
            {
                ssdDisk.Add(disk);
            }
        }

        foreach (Ssd ssd in ssdDisk)
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