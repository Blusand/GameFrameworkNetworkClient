using GameFramework;
using GameFramework.Event;
using Test;

namespace GameMain.Args
{
    public class PlayerInfoEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PlayerInfoEventArgs).GetHashCode();
        public override int Id => EventId;

        public SCPlayerInfo PlayerInfo { get; private set; }

        public PlayerInfoEventArgs()
        {
            PlayerInfo = null;
        }

        public override void Clear()
        {
            PlayerInfo = null;
        }

        public static PlayerInfoEventArgs Create(SCPlayerInfo playerInfo)
        {
            PlayerInfoEventArgs playerInfoEventArgs = ReferencePool.Acquire<PlayerInfoEventArgs>();
            playerInfoEventArgs.PlayerInfo = playerInfo;
            return playerInfoEventArgs;
        }
    }
}