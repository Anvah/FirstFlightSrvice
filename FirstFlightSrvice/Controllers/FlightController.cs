using FirstFlightSrvice.Models;
using FirstFlightSrvice.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstFlightSrvice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService) 
        { 
            _flightService= flightService;
        }
        [HttpGet("/getFlights")]
        public async Task<IEnumerable<Flight>> GetFlights([FromQuery] DateTime? date, [FromQuery] decimal maxPrice = decimal.MaxValue, [FromQuery] int maxTransfersCount = int.MaxValue)
        {
            return await _flightService.GetFlights(date, maxPrice, maxTransfersCount);
        }
        [HttpPost("/bookFlight/{id}")]
        public async Task<Flight> Book(string id)
        {
            return await _flightService.Book(id);
        }
    }
}
