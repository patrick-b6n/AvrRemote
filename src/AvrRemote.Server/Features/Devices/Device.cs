using System.Collections.Generic;

namespace AvrRemote.Server.Features.Devices;

public record Device
(
    string Name,
    string Ip
)
{
    public static IEqualityComparer<Device> IpComparer { get; } = new IpEqualityComparer();

    private sealed class IpEqualityComparer : IEqualityComparer<Device>
    {
        public bool Equals(Device? x, Device? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Ip == y.Ip;
        }

        public int GetHashCode(Device obj)
        {
            return obj.Ip.GetHashCode();
        }
    }
}