using GameFramework;
using Test;

public class CSMessagePacket : CSPacketBase<Message>
{
    public override int Id => (int)CSPacketType.Test;

    public override void Clear()
    {
        Msg.Id = 0;
        Msg.Msg = string.Empty;
    }

    public static CSMessagePacket Create(int id, string msg)
    {
        CSMessagePacket csMessagePacket = ReferencePool.Acquire<CSMessagePacket>();
        csMessagePacket.Msg.Id = id;
        csMessagePacket.Msg.Msg = msg;
        return csMessagePacket;
    }
}