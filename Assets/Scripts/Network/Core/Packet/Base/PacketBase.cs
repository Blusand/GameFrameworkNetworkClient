using System;
using System.IO;
using GameFramework.Network;
using Google.Protobuf;
using UnityGameFramework.Runtime;

public abstract class PacketBase : Packet
{
    public abstract PacketType PacketType { get; protected set; }
    public abstract void Serialize(MemoryStream stream);
    public abstract void Deserialize(Stream source);
    public abstract int GetMsgSize();
}

public abstract class PacketBase<T> : PacketBase where T : class, IMessage, new()
{
    public T Msg { get; private set; } = new T();

    public override void Serialize(MemoryStream stream)
    {
        Msg.WriteTo(stream);
    }

    public override void Deserialize(Stream source)
    {
        try
        {
            Msg = Msg.Descriptor.Parser.ParseFrom(source) as T;
        }
        catch (Exception e)
        {
            Log.Error($"{e} {e.Message}");
            Log.Debug($"协议{Id}解析失败");
        }
    }

    public override int GetMsgSize()
    {
        return Msg.CalculateSize();
    }
}