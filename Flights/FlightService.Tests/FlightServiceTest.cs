namespace FlightService.Tests;

using Flight.Services;
public class FlightServiceTest
{
    [Fact]
    public void IsSegment_WhenInputIsEmpty_ReturnsFalse()
    {
        var flightService = new FlightService();

        var result = flightService.IsSegment(0);

        Assert.False(result, "Empty is not a segment");
    }
}