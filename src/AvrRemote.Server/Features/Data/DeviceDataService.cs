using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AvrRemote.Server.Features.Command;
using AvrRemote.Shared.Features.Data;

namespace AvrRemote.Server.Features.Data;

public class DeviceDataService
{
    private readonly Commander _commander;

    public DeviceDataService(Commander commander)
    {
        _commander = commander;
    }

    public async Task<ZoneState> GetMainZoneState(string ip)
    {
        var state = await _commander.GetMainZoneState(ip);
        return state switch
        {
            "ZMOFF" => ZoneState.Off,
            "ZMON" => ZoneState.On,
            _ => ZoneState.Unknown
        };
    }

    public async Task<ZoneState> GetZone2State(string ip)
    {
        var state = await _commander.GetZone2State(ip);
        return state switch
        {
            "Z2OFF" => ZoneState.Off,
            "Z2ON" => ZoneState.On,
            _ => ZoneState.Unknown
        };
    }

    public async Task<string> GetSubwooferLevel(string ip)
    {
        var value = await _commander.GetSubwooferLevel(ip);
        var match = Regex.Match(value, ".*PSSWL (?<volume>[0-9]+).*");

        return match.Success ? match.Groups["volume"].Value : "-1";
    }

    public async Task<string> GetMasterVolume(string ip)
    {
        var value = await _commander.GetMasterVolume(ip);
        var match = Regex.Match(value, ".*MV(?<volume>[0-9]+).*");

        return match.Success ? match.Groups["volume"].Value : "-1";
    }

    public async Task<MuteState> GetMuteState(string ip)
    {
        var state = await _commander.GetMuteState(ip);

        return state switch
        {
            "MUON" => MuteState.MuteOn,
            "MUOFF" => MuteState.MuteOff,
            _ => MuteState.Unknown
        };
    }
}