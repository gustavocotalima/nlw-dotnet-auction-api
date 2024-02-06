using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction),StatusCodes.Status200OK) ]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuctions()
    {
        var usecase = new GetCurrentAuctionUseCase();
        
        var result = usecase.Execute();
        
        if (result is null)
        {
            return NoContent();
        }
        
        return Ok(result);
    }
}