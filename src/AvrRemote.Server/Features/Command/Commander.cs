using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PrimS.Telnet;

namespace AvrRemote.Server.Features.Command;

public class Commander
{
    private readonly ILogger<Commander> _logger;

    public Commander(ILogger<Commander> logger)
    {
        _logger = logger;
    }

    public async Task Mute(string ip)
    {
        await IssueCommand(ip, "MUON");
    }

    public async Task Unmute(string ip)
    {
        await IssueCommand(ip, "MUOFF");
    }

    public async Task<string> GetMuteState(string ip)
    {
        return await IssueCommand(ip, "MU?");
    }

    public async Task MainZoneOn(string ip)
    {
        await IssueCommand(ip, "ZMON");
    }

    public async Task MainZoneOff(string ip)
    {
        await IssueCommand(ip, "ZMOFF");
    }

    public async Task<string> GetMainZoneState(string ip)
    {
        return await IssueCommand(ip, "ZM?");
    }

    public async Task Zone2On(string ip)
    {
        await IssueCommand(ip, "Z2ON");
    }

    public async Task Zone2Off(string ip)
    {
        await IssueCommand(ip, "Z2OFF");
    }

    public async Task<string> GetZone2State(string ip)
    {
        return await IssueCommand(ip, "Z2?");
    }

    public async Task SetMasterVolume(string ip, int value)
    {
        value = Math.Min(Math.Max(value, 0), 50);
        await IssueCommand(ip, $"MV{value}");
    }

    public async Task<string> GetMasterVolume(string ip)
    {
        return await IssueCommand(ip, "MV?");
    }

    public async Task SetSubwooferLevel(string ip, int value)
    {
        await IssueCommand(ip, $"PSSWL {value}");
    }

    public async Task<string> GetSubwooferLevel(string ip)
    {
        return await IssueCommand(ip, "PSSWL ?");
    }

    private async Task<string> IssueCommand(string ip, string command)
    {
        using var client = new Client(ip, 23, new CancellationToken());

        _logger.LogDebug("Command: ${Command}", command);

        await client.WriteLine(command);
        var response = await client.TerminatedReadAsync(">", TimeSpan.FromMilliseconds(100));
        response = response.Split('\r')[0].Trim();

        _logger.LogDebug("Response: ${Response}", response);

        return response;
    }
}