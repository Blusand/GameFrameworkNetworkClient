using Test;

public class SCMessagePacket : SCPacketBase<Message>
{
    public override int Id => (int)SCPacketType.Test;

    public override void Clear()
    {
        Msg.Id = 0;
        Msg.Msg = string.Empty;
    }
}