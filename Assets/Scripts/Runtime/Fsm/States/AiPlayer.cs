﻿namespace HexCardGame
{
    public class AiPlayer : AiTurn
    {
        public AiPlayer(BattleFsm.BattleFsmArguments args) : base(args)
        {
        }

        protected override SeatType Id => SeatType.Top;
        protected override bool IsAi => GameParameters.Profiles.remotePlayer.isAi;
        protected override bool IsUser => !GameParameters.Profiles.remotePlayer.isAi;
    }
}