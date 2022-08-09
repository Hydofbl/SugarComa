﻿using Assets.MainBoard.Scripts.Route;
using Assets.MainBoard.Scripts.Utils.PlatformUtils;

namespace Assets.MainBoard.Scripts.Player.States
{
    public class PlayerRunningState : PlayerBaseState
    {

        public PlayerRunningState(PlayerStateContext context, PlayerData playerData, PlayerStateFactory factory, string animBoolName) : base(context, playerData, factory, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // Yab
        }

        public override void Exit()
        {
            // Yab


            base.Exit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}
