using System.Collections.Generic;
using System.Linq;
using AvrRemote.Shared.Features.Devices;
using Microsoft.AspNetCore.Mvc;

namespace AvrRemote.Server.Features.Devices;

[ApiController]
[Route("api/[controller]")]
public class DeviceController : ControllerBase
{
    private readonly DeviceLocator _deviceLocator;

    public DeviceController(DeviceLocator deviceLocator)
    {
        _deviceLocator = deviceLocator;
    }

    public IEnumerable<DeviceDto> Index()
    {
        return _deviceLocator.Devices.Select(d => new DeviceDto(Name: d.Name, Ip: d.Ip));
    }
}