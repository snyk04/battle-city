using System;
using System.Threading.Tasks;

namespace BattleCity.Common
{
    public static class Tasks
    {
        public static async Task DoAfterDelay(Action todo, int delay)
        {
            await Task.Delay(delay);
            todo();
        }
    }
}