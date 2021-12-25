using UnityEngine;

namespace BattleCity.AI.Pathfinding
{
    public class FieldPathfinderComponent : MonoBehaviour
    {
        [SerializeField] private FieldContainerComponent _fieldContainer;

        public FieldPathfinderHelper FieldPathfinderHelper { get; private set; }

        private void Awake()
        {
            FieldPathfinderHelper = new FieldPathfinderHelper(_fieldContainer.FieldContainer, new AStarPathfinder());
        }
    }
}