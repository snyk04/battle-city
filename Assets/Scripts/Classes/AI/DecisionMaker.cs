using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace BattleCity.AI
{
    public class DecisionMaker
    {
        private const int UpdateFrequency = 1000;
        
        private readonly BotInfo _botInfo;

        // TODO : Change to enum
        private bool _isIdle;
        private Transform _lastTarget;

        public DecisionMaker(BotInfo botInfo)
        {
            _botInfo = botInfo;

            MakeDecisionAsync(new CancellationTokenSource().Token);
        }

        public void MakeDecision()
        {
            // TODO : Refactor
            Transform newTarget;
            if (_botInfo.Base == null && _botInfo.PlayerTracker.Player == null)
            {
                if (_isIdle)
                {
                    return;
                }
                ChangeState(new IdleState(_botInfo));
                _isIdle = true;
                return;
            }
            
            if (_botInfo.Base != null && _botInfo.PlayerTracker.Player != null)
            {
                float distanceToBase = (_botInfo.Base.position - _botInfo.Position).magnitude;
                float distanceToPlayer = (_botInfo.PlayerTracker.Player.position - _botInfo.Position).magnitude;

                newTarget = distanceToBase > distanceToPlayer
                    ? _botInfo.PlayerTracker.Player
                    : _botInfo.Base;
            }
            else if (_botInfo.Base != null)
            {
                newTarget = _botInfo.Base;
            }
            else if (_botInfo.PlayerTracker.Player != null)
            {
                newTarget = _botInfo.PlayerTracker.Player;
            }
            else
            {
                return;
            }
            
            if (newTarget == _lastTarget)
            {
                return;
            }
            ChangeState(new KillState(_botInfo, newTarget));
            _isIdle = false;
            _lastTarget = newTarget;
        }
        private async Task MakeDecisionAsync(CancellationToken cancellation)
        {
            await Task.Yield();
            while (!cancellation.IsCancellationRequested)
            {
                MakeDecision();
                
                await Task.Delay(UpdateFrequency, cancellation);
            }
        }

        private void ChangeState(IState state)
        {
            state.StateExpired += MakeDecision;
            _botInfo.ChangeState(state);
            Debug.Log("State changed");
        }
    }
}