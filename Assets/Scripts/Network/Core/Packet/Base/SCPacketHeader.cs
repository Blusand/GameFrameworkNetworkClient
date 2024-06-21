public sealed class SCPacketHeader : PacketHeaderBase
{
    public override PacketType PacketType { get; protected set; } = PacketType.ServerToClient;
}