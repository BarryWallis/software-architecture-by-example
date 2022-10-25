namespace booking_api;

/// <summary>
/// All the information needed for a ticket.
/// </summary>
/// <param name="EventCode">The event code.</param>
/// <param name="EventDate">The event date.</param>
/// <param name="Price">The ticket price.</param>
/// <param name="SeatCode">The seat code.</param>
/// <param name="Quantity">The number of tickets.</param>
public record TicketInformation(string EventCode,
                                DateOnly EventDate,
                                decimal Price,
                                string SeatCode,
                                int Quantity)
{
}
