using Google.Protobuf;
using Test;

namespace GameMain
{
    public class SCMessage : SCPacketBase
    {
        public override int Id => (int)SCPacketType.Test;
        public override IMessage Msg { get; protected set; } = new Message();

        public override void Clear()
        {
            var message = Msg as Message;
            message.Id = 0;
            message.Msg = string.Empty;
        }
    }
}