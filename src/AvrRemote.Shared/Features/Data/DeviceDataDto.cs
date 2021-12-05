namespace AvrRemote.Shared.Features.Data
{
    public enum MuteState
    {
        Unknown,
        MuteOff,
        MuteOn
    }

    public enum ZoneState
    {
        Unknown,
        Off,
        On
    }

    public record DeviceDataDto
    (
        MuteState MuteState,
        string MasterVolume,
        ZoneState MainZoneState,
        ZoneState Zone2State,
        string SubwooferLevel
    );
}