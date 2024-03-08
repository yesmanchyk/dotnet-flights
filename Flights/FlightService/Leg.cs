namespace Flight.Services
{
    public record Leg(
        string Origin, string Destination, 
        DateTimeOffset Departure, DateTimeOffset Arrival
        );
}

