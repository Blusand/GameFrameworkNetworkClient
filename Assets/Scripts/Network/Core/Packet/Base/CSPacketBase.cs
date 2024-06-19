namespace GameMain
{
    public abstract class CSPacketBase : PacketBase
    {
        public override PacketType PacketType { get; protected set; } = PacketType.ClientToServer;
    }
}