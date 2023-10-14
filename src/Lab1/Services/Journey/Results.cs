namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Journey;

public class Results
{
    public Results()
    {
        Lost = false;
        IsShipDied = false;
        IsCrewDied = false;
        Success = false;
        FuelAmount = 0;
        TimeAmount = 0;
        Name = "null";
    }

    public string Name { get; set; }

    public bool Lost { get; set; }
    public bool IsShipDied { get; set; }
    public bool IsCrewDied { get; set; }
    public bool Success { get; set; }

    public double FuelAmount { get; set; }
    public double TimeAmount { get; set; }

    public string ShowResults()
    {
        return $@"Success : {Success}
                  IsShipDied : {IsShipDied}
                  IsCrewDied : {IsCrewDied}
                  Lost : {Lost}
                  FuelAmount : {FuelAmount}
                  TimeAmount : {TimeAmount}";
    }
}