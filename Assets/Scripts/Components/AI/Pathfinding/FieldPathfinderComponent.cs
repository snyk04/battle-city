using UnityEngine;

namespace BattleCity.AI.Pathfinding
{
    public class FieldPathfinderComponent : MonoBehaviour
    {
        [SerializeField] private FieldContainerComponent _fieldContainer;
        
        public FieldPathfinder FieldPathfinder { get; private set; }

        private void Awake()
        {
            FieldPathfinder = new FieldPathfinder(_fieldContainer.FieldContainer, new AStarPathfinder());
        }
    }
}