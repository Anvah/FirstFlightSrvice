﻿using FirstFlightSrvice.Models;

namespace FirstFlightSrvice.Services.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetFlights(DateTime? date, decimal maxPrice = decimal.MaxValue, int maxTransfersCount = int.MaxValue);
        Task<Flight> Book(string Id);
    }
}
