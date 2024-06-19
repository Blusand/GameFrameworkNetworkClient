using System;
using System.IO;
using GameFramework.Network;
using Google.Protobuf;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public abstract class PacketBase : Packet
    {
        public abstract PacketType PacketType { get; protected set; }
        public abstract IMessage Msg { get; protected set; }

        public void Serialize(MemoryStream stream)
        {
            Msg.WriteTo(stream);
        }

        public void Deserialize(Stream source)
        {
            try
            {
                Msg = Msg.Descriptor.Parser.ParseFrom(source);
            }
            catch (Exception e)
            {
                Log.Error($"{e} {e.Message}");
                Log.Debug($"协议{Id}解析失败");
            }
        }

        public int GetMsgSize()
        {
            return Msg.CalculateSize();
        }
    }
}