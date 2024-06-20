using System.Net;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Network;
using GameFramework.Procedure;
using GameMain;
using GameMain.Args;
using Test;
using UnityEngine;
using UnityGameFramework.Runtime;

public class ProcedureNetwork : ProcedureBase
{
    private INetworkChannel m_NetworkChannel;
    private SCPlayerInfo m_ScPlayerInfo;

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        GameEntry.GetComponent<EventComponent>().Subscribe(PlayerInfoEventArgs.EventId, OnGetPlayerInfo);

        m_NetworkChannel =
            GameEntry.GetComponent<NetworkComponent>()
                .CreateNetworkChannel("TestProtobuf", ServiceType.Tcp, new NetworkChannelHelper());
        m_NetworkChannel.Connect(IPAddress.Parse("127.0.0.1"), 9000);
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);

        GameEntry.GetComponent<EventComponent>().Unsubscribe(PlayerInfoEventArgs.EventId, OnGetPlayerInfo);
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
            m_NetworkChannel.Send(CSPlayerInfoPacket.Create(21, "这是客户端发来的请求玩家数据的协议"));
        }
        // 发送Quit消息
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            m_NetworkChannel.Send(CSQuit.Create());
        }
    }

    /// <summary>
    /// 获取玩家信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnGetPlayerInfo(object sender, GameEventArgs e)
    {
        PlayerInfoEventArgs playerInfoEventArgs = (PlayerInfoEventArgs)e;
        Debug.Log(playerInfoEventArgs.PlayerInfo);
        // SCPlayerInfo数据在该函数结束后会被清理为null，如果想要将数据保存下来，
        // 需要new一份新的数据
        m_ScPlayerInfo = new SCPlayerInfo(playerInfoEventArgs.PlayerInfo);
    }
}