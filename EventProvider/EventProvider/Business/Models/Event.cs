// This code was formatted and refined using AI assistance.
namespace EventProvider.Business.Models

{
    /// <summary>
    /// Represents an event in the system.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// The unique identifier for the event.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// A description of the event.
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// The start date and time of the event.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date and time of the event.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The location where the event takes place.
        /// </summary>
        public string Location { get; set; } = null!;

        /// <summary>
        /// The price of a ticket for the event.
        /// </summary>
        public int TicketPrice { get; set; }

        /// <summary>
        /// The number of tickets available for the event.
        /// </summary>
        public string TicketAmount { get; set; } = null!;
    }
}
