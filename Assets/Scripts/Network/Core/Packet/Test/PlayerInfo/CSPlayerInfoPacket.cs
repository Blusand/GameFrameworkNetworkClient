using GameFramework;
using Google.Protobuf;
using Test;

namespace GameMain
{
    public class CSPlayerInfoPacket : CSPacketBase
    {
        public override int Id => (int)CSPacketType.PlayerInfo;
        public override IMessage Msg { get; protected set; } = new CSPlayerInfo();

        public override void Clear()
        {
            var playerInfo = Msg as CSPlayerInfo;
            playerInfo.Id = 0;
            playerInfo.Msg = string.Empty;
        }

        public static CSPlayerInfoPacket Create(int id, string msg)
        {
            CSPlayerInfoPacket csPlayerInfo = ReferencePool.Acquire<CSPlayerInfoPacket>();
            var playerInfo = csPlayerInfo.Msg as CSPlayerInfo;
            playerInfo.Id = id;
            playerInfo.Msg = msg;
            return csPlayerInfo;
        }
    }
}