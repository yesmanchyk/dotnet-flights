namespace FlightService.Tests;

using Flight.Services;
public class FlightServiceTest
{
    private readonly FlightService _flightService = new FlightService();

    [Fact]
    public void ReadFile_WhenPathIsValid_ReturnsLegs()
    {
        var path = GetDomesticFlightPath();

        var result = _flightService.ReadFile(path);

        Assert.Equal(3, result.Count);
        Assert.Equal("IAH", result[0].Origin);
        var offset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now);
        Assert.Equal(new DateTimeOffset(
            2024, 4, 1, 
            8, 0, 0, 0, 
            result[0].Departure.Offset), result[0].Departure); 
        Assert.Equal("ORD", result[0].Destination);
        Assert.Equal("JFK", result[2].Origin);
        Assert.Equal("IAH", result[2].Destination);
    }

    [Fact]
    public void Journey_WhenDomesticFlight_FourHourLayoverSplitsSegments()
    {
        var path = GetDomesticFlightPath();
        var legs = _flightService.ReadFile(path);
        
        var journey = _flightService.Journey(legs);

        Assert.Equal(2, journey.Count);
        Assert.Equal("IAH", journey[0].Origin);
        Assert.Equal("JFK", journey[0].Destination);
        Assert.Equal("JFK", journey[1].Origin);
        Assert.Equal("IAH", journey[1].Destination);
    }


    [Fact]
    public void Journey_WhenInternationalFlight_TwentyFourHourLayoverSplitsSegments()
    {
        var path = GetIternationalFlightPath();
        var legs = _flightService.ReadFile(path);
        
        var journey = _flightService.Journey(legs);

        Assert.Equal(2, journey.Count);
        Assert.Equal("IAH", journey[0].Origin);
        Assert.Equal("BOM", journey[0].Destination);
        Assert.Equal("BOM", journey[1].Origin);
        Assert.Equal("IAH", journey[1].Destination);
    }


    private string GetDomesticFlightPath() => Path.Combine("..", "..", "..", "domestic.csv");

    private string GetIternationalFlightPath() => Path.Combine("..", "..", "..", "international.csv");

}