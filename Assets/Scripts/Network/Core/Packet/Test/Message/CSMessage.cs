using GameFramework;
using Google.Protobuf;
using Test;

namespace GameMain
{
    public class CSMessage : CSPacketBase
    {
        public override int Id => (int)CSPacketType.Test;
        public override IMessage Msg { get; protected set; } = new Message();

        public override void Clear()
        {
            var message = Msg as Message;
            message.Id = 0;
            message.Msg = string.Empty;
        }

        public static CSMessage Create(int id, string msg)
        {
            CSMessage csMessage = ReferencePool.Acquire<CSMessage>();
            var message = csMessage.Msg as Message;
            message.Id = id;
            message.Msg = msg;
            return csMessage;
        }
    }
}