using Microsoft.AspNetCore.Mvc;

namespace booking_api.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class ExternalTicketBookingController : ControllerBase
{
    private static readonly Random _random = new();
    private static readonly int _capacity = 1_200_000;
    private static readonly string _eventCode = "GLS_21";
    private static readonly DateOnly _eventDate = new(2021, 06, 23);
    private static readonly decimal[] _prices = new[] { 100.50M, 260.65M, 540.10M };

    public ExternalTicketBookingController()
    {
    }

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

    [HttpPost("{seatCode?}")]
#pragma warning disable IDE0060 // Remove unused parameter
    public async Task<IActionResult> ReserveTicket(string seatCode)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        await Task.Delay(1_000);
        return _random.Next(10) == 1 ? BadRequest() : Ok();
    }

    [HttpPost("{seatCode?}")]
#pragma warning disable IDE0060 // Remove unused parameter
    public async Task<IActionResult> PurchaseTicket(string seatCode)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        await Task.Delay(2_000);
        return _random.Next(10) == 1 ? BadRequest() : Ok();
    }
}
