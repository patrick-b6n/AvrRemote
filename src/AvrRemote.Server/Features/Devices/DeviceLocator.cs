using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Rssdp;

namespace AvrRemote.Server.Features.Devices;

public class DeviceLocator
{
    private static readonly List<string> AllowedDeviceTypes = new()
    {
        "urn:schemas-denon-com:device:AiosDevice:1"
    };

    private readonly ILogger<DeviceLocator> _logger;

    public DeviceLocator(ILogger<DeviceLocator> logger)
    {
        _logger = logger;
        Devices = Enumerable.Empty<Device>();
    }

    public IEnumerable<Device> Devices { get; private set; }

    public async Task SearchForDevices()
    {
        using var deviceLocator = new SsdpDeviceLocator();
        var foundDevices = await deviceLocator.SearchAsync(TimeSpan.FromSeconds(5));

        var devices = new List<Device>();
        foreach (var foundDevice in foundDevices)
        {
            _logger.LogDebug("Found ${DeviceUsn} at ${DeviceLocation}", foundDevice.Usn, foundDevice.DescriptionLocation);

            var fullDevice = await foundDevice.GetDeviceInfo();
            if (AllowedDeviceTypes.Contains(fullDevice.FullDeviceType)) devices.Add(new Device(fullDevice.FriendlyName, foundDevice.DescriptionLocation.Host));
        }

        Devices = devices.Distinct(Device.IpComparer);
    }
}