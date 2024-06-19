using System.Net;
using GameFramework.Fsm;
using GameFramework.Network;
using GameFramework.Procedure;
using GameMain;
using UnityEngine;
using UnityGameFramework.Runtime;

public class ProcedureNetwork : ProcedureBase
{
    private INetworkChannel m_NetworkChannel;

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        m_NetworkChannel =
            GameEntry.GetComponent<NetworkComponent>()
                .CreateNetworkChannel("TestProtobuf", ServiceType.Tcp, new NetworkChannelHelper());
        m_NetworkChannel.Connect(IPAddress.Parse("127.0.0.1"), 9000);
    }

    protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds,
        float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        // 关闭连接
        if (Input.GetKeyDown(KeyCode.C))
        {
            m_NetworkChannel.Close();
        }
        // 发送Message消息
        else if (Input.GetKeyDown(KeyCode.S))
        {
            m_NetworkChannel.Send(CSMessage.Create(165511, "这是客户端发来的消息"));
        }
        // 发送PlayerInfo消息
        else if (Input.GetKeyDown(KeyCode.P))
        {
            m_NetworkChannel.Send(CSPlayerInfo.Create(21, "玩家1", 13, 340, 102645.23f, "这个玩家很懒，什么都没有写"));
        }
        // 发送Quit消息
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            m_NetworkChannel.Send(CSQuit.Create());
        }
    }
}