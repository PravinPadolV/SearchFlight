using System;
using System.Collections.Generic;
using System.Linq;
using ProviderDAL;
using ProviderDAL.Models;

namespace SearchFlights
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the command");
            string command = Console.ReadLine();
            string origin = command.Split(' ')[2];
            string destination = command.Split(' ')[4];
            ProviderData provider = new ProviderData();            
            try
            {
                List<FlightDetail> list = provider.GetProviderData();
                var availableFlights = list.Where(a => a.Origin.Equals(origin) && a.Destination.Equals(destination))
                    .Distinct(new EqualityComparer())
                    .OrderBy(a => a.Price).ThenBy(a => a.DepartureTime);
                if (availableFlights != null && availableFlights.Any())
                    foreach (var flight in availableFlights)
                        Console.WriteLine(origin + "  --> " + destination + " (" + flight.DepartureTime + " --> " + flight.DepartureTime + ") - " + flight.Price);
                else
                    Console.WriteLine("No Flights Found for " + origin + " --> " + destination);
            }
            catch (Exception)
            {
                Console.WriteLine("No Flights Found for " + origin + " --> " + destination);
            }
            
        }
    }
}
