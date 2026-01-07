namespace SEMBS.SEMBS.Models.Entities
{
    public class Bookings
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public bool Status { get; set; }
    }
}