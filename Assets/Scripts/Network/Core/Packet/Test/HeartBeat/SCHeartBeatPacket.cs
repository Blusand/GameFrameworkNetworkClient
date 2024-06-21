using Test;

public class SCHeartBeatPacket : SCPacketBase<HeartBeat>
{
    public override int Id => (int)SCPacketType.HeartBeat;

    public override void Clear()
    {
    }
}