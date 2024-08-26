using AppleAccounts.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppleAccounts.Controllers;
[ApiController]
[Route("[controller]")]
public class AppleIdApiController(IAppleIdService service) : ControllerBase
{
    private readonly IAppleIdService _service = service;
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? expired, [FromQuery] string? filterQuery) => Ok(await _service.GetAppleIds(!string.IsNullOrWhiteSpace(expired), filterQuery));

    [HttpGet("{id}")]
    [Tags("Get AppleId by ID")]
    public async Task<IActionResult> Get(int id)
    {
        var appleId = await _service.GetAppleId(id);
        if (appleId == null)
            return NotFound();
        return Ok(appleId);
    }

}