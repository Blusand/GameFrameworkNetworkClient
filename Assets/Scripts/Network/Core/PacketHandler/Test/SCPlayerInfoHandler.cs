using GameFramework.Network;
using UnityEngine;

namespace GameMain
{
    public class SCPlayerInfoHandler : PacketHandlerBase
    {
        public override int Id => (int)SCPacketType.PlayerInfo;
        public override void Handle(object sender, Packet packet)
        {
            SCPlayerInfo scPlayerInfo = packet as SCPlayerInfo;
            Debug.Log(scPlayerInfo.Msg);
        }
    }
}