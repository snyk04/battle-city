using UnityEngine;

namespace BattleCity.AI
{
    public class DecisionMaker
    {
        private readonly BotInfo _botInfo;

        public DecisionMaker(BotInfo botInfo)
        {
            _botInfo = botInfo;
        }

        public void MakeDecision()
        {
            if (_botInfo.Base == null && _botInfo.PlayerTracker.Player == null)
            {
                ChangeState(new IdleState(_botInfo));
            }
            else if (_botInfo.Base != null && _botInfo.PlayerTracker.Player != null)
            {
                float distanceToBase = (_botInfo.Base.position - _botInfo.Position).magnitude;
                float distanceToPlayer = (_botInfo.PlayerTracker.Player.position - _botInfo.Position).magnitude;

                Transform newTarget = distanceToBase > distanceToPlayer 
                    ? _botInfo.PlayerTracker.Player 
                    : _botInfo.Base;
                
                ChangeState(new KillState(_botInfo, newTarget));
            }
            else if (_botInfo.Base != null)
            {
                ChangeState(new KillState(_botInfo, _botInfo.Base));
            }
            else if (_botInfo.PlayerTracker.Player != null)
            {
                ChangeState(new KillState(_botInfo, _botInfo.PlayerTracker.Player));
            }
        }

        private void ChangeState(IState state)
        {
            state.StateExpired += MakeDecision;
            _botInfo.ChangeState(state);
        }
    }
}