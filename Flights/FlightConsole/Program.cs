// See https://aka.ms/new-console-template for more information
using Flight.Services;

class FlintConsole
{
    public static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine($"Usage: dotnet run flight.csv");
            return;
        }
        var flightService = new FlightService();
        var legs = flightService.ReadFile(args[0]);
        var segments = flightService.Journey(legs);
        foreach(var segment in segments)
        {
            Console.WriteLine($"{segment.Origin}, {segment.Destination}, {segment.Departure}, {segment.Arrival}");
        }
    }
}



