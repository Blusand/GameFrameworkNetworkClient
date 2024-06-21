using Test;

public class SCPlayerInfoPacket : SCPacketBase<SCPlayerInfo>
{
    public override int Id => (int)SCPacketType.PlayerInfo;

    public override void Clear()
    {
        Msg.Id = 0;
        Msg.Name = string.Empty;
        Msg.Lv = 0;
        Msg.Exp = 0;
        Msg.Gold = 0f;
        Msg.Desc = string.Empty;
    }
}