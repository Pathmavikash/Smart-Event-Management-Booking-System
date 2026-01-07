namespace SEMBS.SEMBS.Models.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public int Capacity { get; set; }
        public int OrganizerId { get; set; }
    }
}
