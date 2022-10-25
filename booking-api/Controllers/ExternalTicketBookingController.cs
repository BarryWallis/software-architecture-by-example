using Microsoft.AspNetCore.Mvc;

namespace booking_api.Controllers;
/// <summary>
/// This is a mock class to provide simple sample data.
/// </summary>
[ApiController]
[Route("[controller]/[action]")]
public class ExternalTicketBookingController : ControllerBase
{
    private static readonly Random _random = new();
    private static readonly int _capacity = 1_200_000;
    private static readonly string _eventCode = "GLS_21";
    private static readonly DateOnly _eventDate = new(2021, 06, 23);
    private static readonly decimal[] _prices = new[] { 100.50M, 260.65M, 540.10M };

    /// <summary>
    /// Create a new external ticketing controller.
    /// </summary>
    public ExternalTicketBookingController()
    {
    }

    /// <summary>
    /// Get an enumaration of all available tickets,
    /// </summary>
    /// <returns>The enumaration of available tickets.</returns>
    [HttpGet]
    public IEnumerable<TicketInformation> GetTickets()
    {
        List<TicketInformation> tickets = new();
        for (int i = 0; i < _prices.Length; i++)
        {
            tickets.Add(new TicketInformation(_eventCode,
                                              _eventDate,
                                              _prices[_random.Next(_prices.Length)],
                                              SeatCode: "NA",
                                              Quantity: _capacity / _prices.Length));
        }

        return tickets;
    }

    /// <summary>
    /// Request to reserve a ticket.
    /// </summary>
    /// <param name="seatCode">The seat code of the ticket to be reserved.</param>
    /// <returns>The result of the request.</returns>
    [HttpPost("{seatCode?}")]
#pragma warning disable IDE0060 // Remove unused parameter
    public async Task<IActionResult> ReserveTicket(string seatCode)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        await Task.Delay(1_000);
        return _random.Next(10) == 1 ? BadRequest() : Ok();
    }

    /// <summary>
    /// Request to purchase a ticket.
    /// </summary>
    /// <param name="seatCode">The seat code of the ticket to be purchased.</param>
    /// <returns>The result of the request.</returns>
    [HttpPost("{seatCode?}")]
#pragma warning disable IDE0060 // Remove unused parameter
    public async Task<IActionResult> PurchaseTicket(string seatCode)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        await Task.Delay(2_000);
        return _random.Next(10) == 1 ? BadRequest() : Ok();
    }
}
