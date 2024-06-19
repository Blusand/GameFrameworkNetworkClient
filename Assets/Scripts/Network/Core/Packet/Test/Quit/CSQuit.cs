using GameFramework;
using Google.Protobuf;
using Test;

namespace GameMain
{
    public class CSQuit : CSPacketBase
    {
        public override int Id => (int)CSPacketType.Quit;

        public override IMessage Msg { get; protected set; } = new Quit();

        public override void Clear()
        {
        }

        public static CSQuit Create()
        {
            return ReferencePool.Acquire<CSQuit>();
        }
    }
}