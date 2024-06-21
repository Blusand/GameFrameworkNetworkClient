using Test;

public class CSHeartBeatPacket : CSPacketBase<HeartBeat>
{
    public override int Id => (int)CSPacketType.HeartBeat;

    public override void Clear()
    {
    }
}