using System.Threading.Tasks;
using AvrRemote.Shared.Features.Data;
using Microsoft.AspNetCore.Mvc;

namespace AvrRemote.Server.Features.Data;

[ApiController]
[Route("api/[controller]")]
public class DeviceDataController : ControllerBase
{
    private readonly DeviceDataService _deviceDataService;

    public DeviceDataController(DeviceDataService deviceDataService)
    {
        _deviceDataService = deviceDataService;
    }

    public async Task<DeviceDataDto> Index([FromQuery] string ip)
    {
        var deviceInformation = new DeviceDataDto(
            await _deviceDataService.GetMuteState(ip),
            await _deviceDataService.GetMasterVolume(ip),
            await _deviceDataService.GetMainZoneState(ip),
            await _deviceDataService.GetZone2State(ip),
            await _deviceDataService.GetSubwooferLevel(ip)
        );

        return deviceInformation;
    }
}