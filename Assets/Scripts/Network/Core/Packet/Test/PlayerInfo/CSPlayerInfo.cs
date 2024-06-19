using GameFramework;
using Google.Protobuf;
using Test;

namespace GameMain
{
    public class CSPlayerInfo : CSPacketBase
    {
        public override int Id => (int)CSPacketType.PlayerInfo;
        public override IMessage Msg { get; protected set; } = new PlayerInfo();

        public override void Clear()
        {
            var playerInfo = Msg as PlayerInfo;
            playerInfo.Id = 0;
            playerInfo.Name = string.Empty;
            playerInfo.Lv = 0;
            playerInfo.Exp = 0;
            playerInfo.Gold = 0f;
            playerInfo.Desc = string.Empty;
        }

        public static CSPlayerInfo Create(int id, string name, int lv, int exp, float gold, string desc)
        {
            CSPlayerInfo csPlayerInfo = ReferencePool.Acquire<CSPlayerInfo>();
            var playerInfo = csPlayerInfo.Msg as PlayerInfo;
            playerInfo.Id = id;
            playerInfo.Name = name;
            playerInfo.Lv = lv;
            playerInfo.Exp = exp;
            playerInfo.Gold = gold;
            playerInfo.Desc = desc;
            return csPlayerInfo;
        }
    }
}