namespace EventProvider.Business.Models
{
    /// <summary>
    /// Represents the data required to register or create a new event.
    /// </summary>
    public class EventRegistrationModel
    {
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
        /// The location where the event will take place.
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
