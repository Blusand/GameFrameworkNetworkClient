﻿using GameFramework.Network;
using UnityEngine;

namespace GameMain
{
    public class SCHeartBeatHandler : PacketHandlerBase
    {
        public override int Id => (int)SCPacketType.HeartBeat;

        public override void Handle(object sender, Packet packet)
        {
            SCHeartBeat packetImpl = (SCHeartBeat)packet;
            Debug.Log($"接收心跳：{packetImpl.Id}");
        }
    }
}