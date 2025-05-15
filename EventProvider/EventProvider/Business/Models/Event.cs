namespace EventProvider.Business.Models
{
    public class Event
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = null!;
        public int TicketPrice { get; set; }
        public string TicketAmount { get; set; } = null!;
        
    }
}
