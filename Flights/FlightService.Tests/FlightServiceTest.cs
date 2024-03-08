namespace FlightService.Tests;

using Flight.Services;
public class FlightServiceTest
{
    private readonly FlightService _flightService = new FlightService();

    [Fact]
    public void IsSegment_WhenInputIsEmpty_ReturnsFalse()
    {
        var result = _flightService.IsSegment(0);

        Assert.False(result, "Empty is not a segment");
    }

    [Fact]
    public void ReadFile_WhenPathIsValid_ReturnsLegs()
    {
        var path = Path.Combine("..", "..", "..", "iah-jfk.csv");

        var result = _flightService.ReadFile(path);

        Assert.Equal(3, result.Count);
        Assert.Equal("IAH", result[0].Origin);
        Assert.Equal("ORD", result[0].Destination);
        Assert.Equal("JFK", result[2].Origin);
        Assert.Equal("IAH", result[2].Destination);
    }
}