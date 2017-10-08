namespace MVC.Models
{
    public class SeatingChart
    {
        public int SeatId { get; set; }
        public int Section { get; set; }
        public int Seat { get; set; }
        public bool IsTaken { get; set; }
        public int FlightID { get; set; }
        public Flight Flight { get; set; }
    }
}