public sealed class CSPacketHeader : PacketHeaderBase
{
    public override PacketType PacketType { get; protected set; } = PacketType.ClientToServer;
}