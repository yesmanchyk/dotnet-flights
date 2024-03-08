// See https://aka.ms/new-console-template for more information
using Flight.Services;

var flightService = new FlightService();

Console.WriteLine($"Hello, {flightService.IsSegment(0)}");
