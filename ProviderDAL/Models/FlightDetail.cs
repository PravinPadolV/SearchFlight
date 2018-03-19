using System;

namespace ProviderDAL.Models
{
    public class FlightDetail
    {
        public string Origin { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime DestinationTime { get; set; }
        public string Price { get; set; }  
    }
}
