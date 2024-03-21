using FirstFlightSrvice.Models;
using FirstFlightSrvice.Services.Interfaces;

namespace FirstFlightSrvice.Services
{
    public class FlightService: IFlightService
    {
        private static List<Flight> firstFlights = new List<Flight>
            {
               new Flight
                {
                    Id = "NYC-LON-PAR-1",
                    Airline = "Example Airways",
                    DeparturePoint = new Transfer
                    {
                        Airport = "JFK JFK JFK",
                        DepartureDataTime = DateTime.UtcNow,
                    },
                    ArrivalPoint = new Transfer
                    {
                        Airport = "LHR JFK JFK",
                        ArrivalDataTime = DateTime.UtcNow.AddHours(8),
                    },
                    Transfers = new Transfer[]
                    {
                        new Transfer
                        {
                            Airport = "CDG JFK JFK",
                            ArrivalDataTime = DateTime.UtcNow.AddHours(3),
                            DepartureDataTime = DateTime.UtcNow.AddHours(4),
                        }
                    },
                    Price = 1200.00m
                },
               new Flight
               {
                   Id = "PAR-TYO-1",
                   Airline = "Example Airways",
                   DeparturePoint = new Transfer
                   {
                       Airport = "CDG JFK JFK",
                       DepartureDataTime = DateTime.UtcNow,
                   },
                   ArrivalPoint = new Transfer
                   {
                       Airport = "HND JFK JFK",
                       ArrivalDataTime = DateTime.UtcNow.AddHours(14),
                   },
                   Transfers = new Transfer[] { },
                   Price = 1800.00m
               },
               new Flight
               {
                   Id = "LAX-SYD-AKL-1",
                   Airline = "Example Airways",
                   DeparturePoint = new Transfer
                   {
                       Airport = "LAX JFK JFK",
                       DepartureDataTime = DateTime.UtcNow,
                   },
                   ArrivalPoint = new Transfer
                   {
                       Airport = "SYD JFK JFK",
                       ArrivalDataTime = DateTime.UtcNow.AddHours(20),
                   },
                   Transfers = new Transfer[]
                    {
                        new Transfer
                        {
                            Airport = "AKL JFK JFK",
                            ArrivalDataTime = DateTime.UtcNow.AddHours(15),
                            DepartureDataTime = DateTime.UtcNow.AddHours(16),
                        }
                    },
                   Price = 2500.00m
               },
               new Flight
               {
                   Id = "SHA-ICN-1",
                   Airline = "Example Airways",
                   DeparturePoint = new Transfer
                   {
                       Airport = "PVG JFK JFK",
                       DepartureDataTime = DateTime.UtcNow,
                   },
                   ArrivalPoint = new Transfer
                   {
                       Airport = "ICN JFK JFK",
                       ArrivalDataTime = DateTime.UtcNow.AddHours(2),
                   },
                   Transfers = new Transfer[] { },
                   Price = 900.00m
               }


            };
        async public Task<Flight> Book(string Id)
        {
            var flight = firstFlights.FirstOrDefault(f => f.Id == Id);
            if (flight != null && !flight.IsBooked)
                flight.IsBooked = true;
            return flight;
        }

        public async Task<IEnumerable<Flight>> GetFlights(DateTime? date, decimal maxPrice = decimal.MaxValue, int maxTransfersCount = int.MaxValue)
        {
            var sortedFlight = firstFlights
                .Where(f => (date == null || f.DeparturePoint.DepartureDataTime.Date == date?.Date)
                && f.Price < maxPrice
                && f.Transfers.Length < maxTransfersCount
                );
            return sortedFlight;
        }
    }
}
