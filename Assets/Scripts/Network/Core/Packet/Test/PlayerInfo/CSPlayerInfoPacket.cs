using GameFramework;
using Test;

public class CSPlayerInfoPacket : CSPacketBase<CSPlayerInfo>
{
    public override int Id => (int)CSPacketType.PlayerInfo;

    public override void Clear()
    {
        Msg.Id = 0;
        Msg.Msg = string.Empty;
    }

    public static CSPlayerInfoPacket Create(int id, string msg)
    {
        CSPlayerInfoPacket csPlayerInfo = ReferencePool.Acquire<CSPlayerInfoPacket>();
        csPlayerInfo.Msg.Id = id;
        csPlayerInfo.Msg.Msg = msg;
        return csPlayerInfo;
    }
}