using GameFramework.Network;
using UnityGameFramework.Runtime;

public class SCPlayerInfoHandler : PacketHandlerBase
{
    public override int Id => (int)SCPacketType.PlayerInfo;

    public override void Handle(object sender, Packet packet)
    {
        SCPlayerInfoPacket scPlayerInfoPacket = packet as SCPlayerInfoPacket;
        //Debug.Log(scPlayerInfoPacket.Msg);

        GameEntry.GetComponent<EventComponent>()
            .FireNow(this, PlayerInfoEventArgs.Create(scPlayerInfoPacket.Msg));
    }
}