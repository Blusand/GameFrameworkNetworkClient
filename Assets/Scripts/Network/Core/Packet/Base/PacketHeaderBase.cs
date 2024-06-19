using System;
using System.IO;
using GameFramework;
using GameFramework.Network;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public abstract class PacketHeaderBase : IPacketHeader, IReference
    {
        public abstract PacketType PacketType { get; protected set; }

        public int Id { get; set; }

        public int PacketLength { get; set; }

        public bool IsValid => PacketType != PacketType.Undefined && Id > 0 && PacketLength >= 0;

        private byte[] m_CacheBytes = new byte[sizeof(int)];

        public void Clear()
        {
            Id = 0;
            PacketLength = 0;
            Array.Clear(m_CacheBytes, 0, m_CacheBytes.Length);
        }

        public void Serialize(Stream stream)
        {
            stream.Write(BitConverter.GetBytes(Id));
            stream.Write(BitConverter.GetBytes(PacketLength));
        }

        public void Deserialize(Stream source)
        {
            Id = ReadInt(source, m_CacheBytes);
            PacketLength = ReadInt(source, m_CacheBytes);
        }

        private int ReadInt(Stream source, byte[] bytes)
        {
            int readLength = source.Read(bytes);
            if (readLength == 0)
            {
                Log.Debug("读取字节出错");
            }

            return BitConverter.ToInt32(bytes);
        }
    }
}