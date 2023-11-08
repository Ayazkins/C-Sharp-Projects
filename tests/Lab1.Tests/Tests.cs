using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Area;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Journey;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ShipFactory;
using Xunit;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    private readonly ITestOutputHelper _outputHelper;

    public Tests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory]
    [InlineData(1000)]
    public void TestWalkerAndAvgurInNebulaDensity(int i)
    {
        IList<AreaBase> list = new List<AreaBase>();
        var walker = new ShipBase(new Walker());
        var nebulaeDensity = new NebulaeDensity(i);
        var result = new Results();
        list.Add(nebulaeDensity);
        var route = new Route(list);
        var test = new ShipRouteChecker(result);

        test.Go(walker, route);

        Assert.False(result.Success);
        Assert.True(result.Lost);
        _outputHelper.WriteLine(result.ShowResults());

        var avgur = new ShipBase(new Avgur());
        var result2 = new Results();
        var test2 = new ShipRouteChecker(result2);

        test2.Go(avgur, route);

        Assert.False(result2.Success);
        Assert.True(result2.Lost);
        _outputHelper.WriteLine(result2.ShowResults());
    }

    [Theory]
    [InlineData(1000)]
    public void TestVaklasPhotonDeflectors(int i)
    {
        IList<AreaBase> list = new List<AreaBase>();
        var ship = new ShipBase(new Vaklas());
        var obstacle = new AntiMateria(1);
        var cosmos = new NebulaeDensity(i, obstacle);
        var result = new Results();
        var test = new ShipRouteChecker(result);
        list.Add(cosmos);

        IList<AreaBase> list2 = new List<AreaBase>();
        var ship2 = new ShipBase(new Vaklas(), true);
        var obstacle2 = new AntiMateria(1);
        var cosmos2 = new NebulaeDensity(i, obstacle2);
        list2.Add(cosmos2);
        var result2 = new Results();
        var test2 = new ShipRouteChecker(result2);

        test.Go(ship, new Route(list));

        test2.Go(ship2, new Route(list2));

        Assert.True(result2.Success);
        Assert.False(result2.IsCrewDied);

        Assert.False(result.Success);
        Assert.True(result.IsCrewDied);
    }

    [Theory]
    [InlineData(500)]
    public void CosmoWhaleTestVaklas(int i)
    {
        IList<AreaBase> list = new List<AreaBase>();
        var vaklas = new ShipBase(new Vaklas());
        var cosmowhale = new CosmoWhale(1);
        var nebulaeN = new NebulaN(i, cosmowhale);
        var result = new Results();
        list.Add(nebulaeN);
        var route = new Route(list);
        var test = new ShipRouteChecker(result);

        test.Go(vaklas, route);
        _outputHelper.WriteLine(result.ShowResults());

        Assert.False(result.Success);
        Assert.True(result.IsShipDied);
    }

    [Theory]
    [InlineData(500)]
    public void CosmoWhaleTestAvgur(int i)
    {
        IList<AreaBase> list = new List<AreaBase>();
        var avgur = new ShipBase(new Avgur());
        var cosmowhale = new CosmoWhale(1);
        var nebulaeN = new NebulaN(i, cosmowhale);
        var result = new Results();
        list.Add(nebulaeN);
        var route = new Route(list);
        var test = new ShipRouteChecker(result);

        test.Go(avgur, route);

        Assert.Equal(0, avgur.Deflector.CurrentHitPoints);
        Assert.True(result.Success);
        _outputHelper.WriteLine(result.ShowResults());
    }

    [Theory]
    [InlineData(500)]
    public void CosmoWhaleTestMeredian(int i)
    {
        IList<AreaBase> list = new List<AreaBase>();
        var meredian = new ShipBase(new Meredian());
        var cosmowhale = new CosmoWhale(1);
        var nebulaeN = new NebulaN(i, cosmowhale);
        var result = new Results();
        list.Add(nebulaeN);
        var route = new Route(list);
        var test = new ShipRouteChecker(result);

        test.Go(meredian, route);

        Assert.True(meredian.Deflector.CurrentHitPoints > 0);
        Assert.True(result.Success);
        _outputHelper.WriteLine(result.ShowResults());
    }

    [Fact]
    public void WalkerAndVaklasCosmos()
    {
        IList<AreaBase> list = new List<AreaBase>();
        list.Add(new Cosmos(500));
        list.Add(new Cosmos(1000));
        var vaklas = new ShipBase(new Vaklas());
        var walker = new ShipBase(new Walker());
        var route = new Route(list);
        IList<ShipBase> ships = new List<ShipBase>();
        ships.Add(vaklas);
        ships.Add(walker);

        var test = new ChooseBest();
        string output = test.Choose(ships, route);

        Assert.Equal("Walker", output);
    }

    [Fact]
    public void AvgurAnsStellaInNebulaeDensity()
    {
        IList<AreaBase> list = new List<AreaBase>();
        list.Add(new NebulaeDensity(750));
        var avgur = new ShipBase(new Avgur());
        var stella = new ShipBase(new Stella());
        var route = new Route(list);
        IList<ShipBase> ships = new List<ShipBase>();
        ships.Add(avgur);
        ships.Add(stella);

        var test = new ChooseBest();
        string output = test.Choose(ships, route);

        Assert.Equal("Stella", output);
    }

    [Fact]
    public void WalkerAndVaklasInNebulaeN()
    {
        IList<AreaBase> list = new List<AreaBase>();
        list.Add(new NebulaN(1000));
        var walker = new ShipBase(new Walker());
        var vaklas = new ShipBase(new Vaklas());
        var route = new Route(list);
        IList<ShipBase> ships = new List<ShipBase>();
        ships.Add(walker);
        ships.Add(vaklas);

        var test = new ChooseBest();
        string output = test.Choose(ships, route);

        Assert.Equal("Vaklas", output);
    }

    [Fact]
    public void Avgur()
    {
        IList<AreaBase> list = new List<AreaBase>();
        list.Add(new NebulaN(1000, new CosmoWhale(1)));
        list.Add(new Cosmos(500, new Meteor(1)));
        var route = new Route(list);
        var result = new Results();
        var avgur = new ShipBase(new Avgur());
        var test = new ShipRouteChecker(result);

        test.Go(avgur, route);

        Assert.True(result.Success);
        Assert.Equal(0, avgur.Deflector.CurrentHitPoints);
        Assert.True(avgur.Shell.CurrentHitPoints > 0);
    }
}