using GameFramework.Network;
using Test;
using UnityEngine;

namespace GameMain
{
    public class SCTestHandler : PacketHandlerBase
    {
        public override int Id => (int)SCPacketType.Test;

        public override void Handle(object sender, Packet packet)
        {
            SCMessage scTest = packet as SCMessage;
            if (scTest?.Msg is Message msg)
            {
                Debug.Log($"{msg.Id} {msg.Msg}");
            }
        }
    }
}