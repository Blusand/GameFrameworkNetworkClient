using Google.Protobuf;

public abstract class SCPacketBase<T> : PacketBase<T> where T : class, IMessage, new()
{
    public override PacketType PacketType { get; protected set; } = PacketType.ServerToClient;
}