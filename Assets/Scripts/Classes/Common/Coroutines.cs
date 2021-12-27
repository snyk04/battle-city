using System;
using System.Collections;
using UnityEngine;

namespace BattleCity.Common
{
    public static class Coroutines
    {
        private static IEnumerator DoAfterDelay(Action toDo, float delay)
        {
            yield return new WaitForSeconds(delay);
            toDo();
        }
    }
}