namespace SEMBS.SEMBS.Models.Entities
{
    public class BookingDTO
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public bool Status { get; set; }
    }
}