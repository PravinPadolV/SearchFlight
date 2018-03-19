using ProviderDAL.Common;
using ProviderDAL.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProviderDAL
{
    public class ProviderData
    {
        public List<FlightDetail> GetProviderData()
        {
            List<FlightDetail> flightDetails;
            flightDetails = GetFlightData(',', ProviderFileNames.Provider1);
            flightDetails.AddRange(GetFlightData(',', ProviderFileNames.Provider2));
            flightDetails.AddRange(GetFlightData('|', ProviderFileNames.Provider3));
            return flightDetails;
        }
        private List<FlightDetail> GetFlightData(char separator, string fileName)
        {            
            List<FlightDetail> flightDetails = new List<FlightDetail>();
            int lineCount = 0;
            foreach (var line in File.ReadAllLines(fileName))
            {
                if(lineCount == 0)
                {
                    ++lineCount;
                    continue;
                }
                var record = line.Split(separator);
                flightDetails.Add(new FlightDetail
                {
                    Origin = record[0],
                    DepartureTime = Convert.ToDateTime(record[1]),
                    Destination = record[2],
                    DestinationTime = Convert.ToDateTime(record[3]),
                    Price = record[4]
                });
            }
            return flightDetails;
        }
    }
}
