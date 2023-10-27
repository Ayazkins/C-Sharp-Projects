using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCaseComponents;

public class ComputerCase : DetailBase
{
    public ComputerCase(
        string name,
        int height,
        int width,
        int length,
        int lengthOfVideocard,
        int widthOfVideocard,
        IReadOnlyCollection<FormFactor> supportedFormFactor)
        : base(name)
    {
        if (height <= 0)
        {
            throw new NotPositiveValue(nameof(height));
        }

        if (width <= 0)
        {
            throw new NotPositiveValue(nameof(width));
        }

        if (length <= 0)
        {
            throw new NotPositiveValue(nameof(length));
        }

        if (widthOfVideocard <= 0)
        {
            throw new NotPositiveValue(nameof(widthOfVideocard));
        }

        if (lengthOfVideocard <= 0)
        {
            throw new NotPositiveValue(nameof(lengthOfVideocard));
        }

        Height = height;
        Width = width;
        Length = length;
        LengthOfVideocard = lengthOfVideocard;
        WidthOfVideocard = widthOfVideocard;
        SupportedFormFactor = supportedFormFactor;
    }

    public int LengthOfVideocard { get; }
    public int WidthOfVideocard { get; }
    public IReadOnlyCollection<FormFactor> SupportedFormFactor { get; }
    public int Height { get; }
    public int Width { get; }
    public int Length { get; }

    public CaseBuilder Direct()
    {
        CaseBuilder caseBuilder = new CaseBuilder()
            .SetName(Name)
            .SetHeight(Height)
            .SetLength(Length)
            .SetWidth(Width)
            .SetFormFactors(SupportedFormFactor)
            .SetLengthOfVideocard(LengthOfVideocard)
            .SetWidthOfVideocard(WidthOfVideocard);
        return caseBuilder;
    }
}