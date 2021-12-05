namespace AvrRemote.Shared.Features.Command;

public static class CommandRoutes
{
    private const string Base = "api/command";
    
    public const string Mute = $"{Base}/mute";
    public const string Unmute = $"{Base}/unmute";
    public const string MainZoneOn = $"{Base}/main-zone-on";
    public const string MainZoneOff = $"{Base}/main-zone-off";
    public const string SetMasterVolume = $"{Base}/master-volume";
    public const string SetSubwooferLevel = $"{Base}/subwoofer-level";
}