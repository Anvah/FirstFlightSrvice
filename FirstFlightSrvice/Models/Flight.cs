namespace FirstFlightSrvice.Models
{
    public class Flight
    {
        public string Id { get; set; }
        public string Airline { get; set; }
        public Transfer ArrivalPoint { get; set; }
        public Transfer DeparturePoint { get; set; }
        public Transfer[] Transfers { get; set; }
        public decimal Price { get; set; }
        public bool IsBooked { get; set; }
    }
}
