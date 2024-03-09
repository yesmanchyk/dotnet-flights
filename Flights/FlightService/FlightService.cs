using System.Globalization;

namespace Flight.Services
{
    public class FlightService
    {
        public readonly HashSet<string> Domestic =  new(new string[] {"IAH", "ORD", "JFK", "DFW", "DSM"});
        
        public readonly HashSet<string> International = new(new string[] {"BOM", "DBX", "LHR"});

        private const string TimePattern = "M-d-yyyy h:mm";
        
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
                    Departure: ParseTime(cols[2]),
                    Arrival: ParseTime(cols[3])
                );
                result.Add(leg);
            }
            return result;
        }

        public List<Leg> Journey(List<Leg> legs)
        {
            var from = 0;
            var prev = 0;
            var last = 1;
            Leg segment;
            var segments = new List<Leg>();
            while (last < legs.Count)
            {
                var span = legs[last].Departure - legs[prev].Arrival;
                Console.WriteLine($"{last} {legs[last].Destination} {span.TotalMinutes}");
                if (span.TotalMinutes > 4 * 60) 
                {
                    segment = new Leg(legs[from].Origin, legs[prev].Destination, legs[from].Departure, legs[prev].Arrival);
                    segments.Add(segment);
                    from = last;
                }
                prev = last;
                ++last;
            }
            segment = new Leg(legs[from].Origin, legs[prev].Destination, legs[from].Departure, legs[prev].Arrival);
            segments.Add(segment);
            //if (last == legs.Count) throw new Exception("Segment never ends");
            return segments;
        }

        private DateTimeOffset ParseTime(string time) => DateTimeOffset.Parse(time);
            //DateTimeOffset.ParseExact(time, TimePattern, CultureInfo.InvariantCulture);
    }
}