﻿using Assets.MainBoard.Scripts.Utils.PlatformUtils;
using Assets.MainBoard.Scripts.Networking.Utils;
using Assets.MainBoard.Scripts.Networking;
using Assets.MainBoard.Scripts.Route;
using UnityEngine;
using Assets.MainBoard.Scripts.Player.Handlers;
using Assets.MainBoard.Scripts.Networking.MainBoardNetworking;

namespace Assets.MainBoard.Scripts.Player.States
{
    [System.Serializable]
    public class PlayerRunningState : PlayerBaseState
    {
        #region Private Members
        [SerializeField] private PathTracker _pathTracker;
        [SerializeField] private Platform _currentPlatform;
        [SerializeField] private int _currentStep;
        [SerializeField] private PathFinder _pathFinder;

        private Platform[] _path;
        #endregion

        #region Properties
        public PathFinder PathFinder { get => _pathFinder; set => _pathFinder = value; }
        public PathTracker PathTracker { get => _pathTracker; set => _pathTracker = value; }
        public int CurrentStep { get => _currentStep; set { if (value == 0) _path = null; _currentStep = value; } }
        public RouteSelectorDirection SelectorDir { get; set; } = RouteSelectorDirection.None;
        public Platform CurrentPlatform { get => _currentPlatform; set => _currentPlatform = value; }
        #endregion

        public PlayerRunningState(PlayerStateContext context, PlayerData playerData, string animBoolName) : base(context, playerData, animBoolName)
        {
            
        }

        #region Pathtracker
        public void InitializePathTracker()
        {
            _pathTracker.OnTrackingStarted += OnTrackingStarted;
            _pathTracker.OnCurrentPlatformChanged += OnCurrentPlatformChanged;
            _pathTracker.OnTrackingStopped += OnTrackingStopped;
        }

        private void OnTrackingStarted()
        {
        }

        /// <summary>
        /// Test edilecek: Öncesinde current.next yollanıyordu. Şu haliyle çalışmakta şu an için.
        /// </summary>
        private void OnCurrentPlatformChanged()
        {
            var current = _pathTracker.CurrentPlatform;
            if (current != null)
            {
                // Send player's new position
                RemoteMessageHandler.Instance.SendNewPosition(current.position);

                _currentPlatform = current;
                CurrentStep--;
            }
        }

        private void OnTrackingStopped()
        {
            SwitchState(context.Idle);
        }
        #endregion

        public override void Enter()
        {
            base.Enter();

            _path = _pathFinder.ToSelector(_currentPlatform, _currentStep, SelectorDir);

            if (_path == null)
            {
                SwitchState(context.Idle);
                return;
            }

            _pathTracker.StartTracking(_path, PlatformSpec.Goal, _currentPlatform.HasSelector, _currentStep);
        }

        // TODO: Fix it
        // Eğer sandık karakterden bir birim uzaktaysa ve oyuncu 1 atarsa hareket edildikten sonra burada turnover verilip context kapatıldığı için,
        // idlestate içerisindeki goblet taking metodları NullReference hatasına sebep oluyor.
        public override void Exit()
        {
            context.PlayerCollector.CheckCurrentNode(_currentPlatform);
            if (_currentStep <= 0)
            {
                if (_currentPlatform.spec != PlatformSpec.Goal)
                {
                    // IsMyTurn içindeki index ile PlayerTurnHandler içindeki index'i eşle
                    RemoteMessageHandler.Instance.SendTurnOver(context);
                }
            }

            base.Exit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}
