using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AvrRemote.Shared.Features.Command;
using Microsoft.AspNetCore.Mvc;

namespace AvrRemote.Server.Features.Command;

[ApiController]
public class CommandController : Controller
{
    private readonly Commander _commander;

    public CommandController(Commander commander)
    {
        _commander = commander;
    }

    [Route(CommandRoutes.Mute)]
    public async Task<IActionResult> Mute([Required] [FromQuery] string ip)
    {
        await _commander.Mute(ip);
        return Ok();
    }

    [Route(CommandRoutes.Unmute)]
    public async Task<IActionResult> Unmute([Required] [FromQuery] string ip)
    {
        await _commander.Unmute(ip);
        return Ok();
    }

    [Route(CommandRoutes.MainZoneOn)]
    public async Task<IActionResult> MainZoneOn([Required] [FromQuery] string ip)
    {
        await _commander.MainZoneOn(ip);
        return Ok();
    }

    [Route(CommandRoutes.MainZoneOff)]
    public async Task<IActionResult> MainZoneOff([Required] [FromQuery] string ip)
    {
        await _commander.MainZoneOff(ip);
        return Ok();
    }

    [Route(CommandRoutes.SetMasterVolume)]
    public async Task<IActionResult> SetMasterVolume([Required] [FromQuery] string ip,
                                                     [Required] [FromQuery] int value)
    {
        await _commander.SetMasterVolume(ip, value);
        return Ok();
    }

    [Route(CommandRoutes.SetSubwooferLevel)]
    public async Task<IActionResult> SetSubwooferLevel([Required] [FromQuery] string ip,
                                                       [Required] [FromQuery] int value)
    {
        await _commander.SetSubwooferLevel(ip, value);
        return Ok();
    }
}