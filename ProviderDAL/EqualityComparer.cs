using ProviderDAL.Models;
using System.Collections.Generic;

namespace ProviderDAL
{
    public class EqualityComparer : IEqualityComparer<FlightDetail>
    {
        public bool Equals(FlightDetail x, FlightDetail y)
        {
            if (x.Origin.Equals(y.Origin))
                if (x.Destination.Equals(y.Destination))
                    if (x.DepartureTime.Equals(y.DepartureTime))
                        if (x.DestinationTime.Equals(y.DestinationTime))
                            if (x.Price.Equals(y.Price))
                                return true;
            return false;
        }

        public int GetHashCode(FlightDetail obj)
        {
            return obj.Origin.GetHashCode(); 
        }
    }
}
