using System;

namespace Flight.Services
{
    public class FlightService
    {
        public bool IsSegment(int candidate)
        {
            return false;
        }

        public List<Leg> ReadFile(string path)
        {
            var lines = File.ReadLines(path);
            var result = new List<Leg>();
            foreach (var line in lines)
            {
                var cols = line.Split(", ");
                var leg = new Leg
                (
                    Origin: cols[0],
                    Destination: cols[1],
                    Departure: new DateTimeOffset(),
                    Arrival: new DateTimeOffset()
                );
                result.Add(leg);
            }
            return result;
        }

    }
}