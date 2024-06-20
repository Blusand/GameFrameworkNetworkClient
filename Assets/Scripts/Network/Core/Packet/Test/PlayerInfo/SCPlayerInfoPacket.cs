using Google.Protobuf;
using Test;

namespace GameMain
{
    public class SCPlayerInfoPacket : SCPacketBase
    {
        public override int Id => (int)SCPacketType.PlayerInfo;
        public override IMessage Msg { get; protected set; } = new SCPlayerInfo();

        public SCPlayerInfo PlayerInfo => Msg as SCPlayerInfo;

        public override void Clear()
        {
            var playerInfo = Msg as SCPlayerInfo;
            playerInfo.Id = 0;
            playerInfo.Name = string.Empty;
            playerInfo.Lv = 0;
            playerInfo.Exp = 0;
            playerInfo.Gold = 0f;
            playerInfo.Desc = string.Empty;
        }
    }
}