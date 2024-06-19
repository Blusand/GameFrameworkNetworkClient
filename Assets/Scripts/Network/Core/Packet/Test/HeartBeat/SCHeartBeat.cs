using Google.Protobuf;
using Test;

namespace GameMain
{
    public class SCHeartBeat : SCPacketBase
    {
        public override int Id => (int)SCPacketType.HeartBeat;

        public override IMessage Msg { get; protected set; } = new HeartBeat();

        public override void Clear()
        {
        }

    }
}