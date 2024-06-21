using GameFramework;
using Test;

public class CSQuitPacket : CSPacketBase<Quit>
{
    public override int Id => (int)CSPacketType.Quit;

    public override void Clear()
    {
    }

    public static CSQuitPacket Create()
    {
        return ReferencePool.Acquire<CSQuitPacket>();
    }
}