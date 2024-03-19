using FirstFlightSrvice.Models;
using FirstFlightSrvice.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstFlightSrvice.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService) 
        { 
            _flightService= flightService;
        }

        [Route("/getFligts")]
        [HttpGet]
        public async Task<IEnumerable<Flight>> GetFlights(CancellationToken cancellationToken, DateTime? date, decimal maxPrice = decimal.MaxValue, int maxTransfersCount = int.MaxValue)
        {
            return await _flightService.GetFlights(cancellationToken, date, maxPrice, maxTransfersCount);
        }
        [Route("/bookFlight")]
        [HttpPost]
        public async Task<Flight> Book(string Id, CancellationToken cancellationToken)
        {
            return await _flightService.Book(Id, cancellationToken);
        }
    }
}
