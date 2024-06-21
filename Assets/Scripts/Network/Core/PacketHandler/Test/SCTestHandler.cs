using GameFramework.Network;
using UnityEngine;

namespace GameMain
{
    public class SCTestHandler : PacketHandlerBase
    {
        public override int Id => (int)SCPacketType.Test;

        public override void Handle(object sender, Packet packet)
        {
            SCMessagePacket scMessage = packet as SCMessagePacket;
            Debug.Log($"{scMessage.Msg.Id} {scMessage.Msg.Msg}");
        }
    }
}