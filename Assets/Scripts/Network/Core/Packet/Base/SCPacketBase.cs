namespace GameMain
{
    public abstract class SCPacketBase : PacketBase
    {
        public override PacketType PacketType { get; protected set; } = PacketType.ServerToClient;
    }
}