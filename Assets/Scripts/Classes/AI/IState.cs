using System;

namespace BattleCity.AI
{
    public interface IState
    {
        event Action StateExpired;
        void Update();
    }
}