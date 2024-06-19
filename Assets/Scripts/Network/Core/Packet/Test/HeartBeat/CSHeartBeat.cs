using Google.Protobuf;
using Test;

namespace GameMain
{
    public class CSHeartBeat : CSPacketBase
    {
        public override int Id => (int)CSPacketType.HeartBeat;

        public override IMessage Msg { get; protected set; } = new HeartBeat();

        public override void Clear()
        {
        }
    }
}