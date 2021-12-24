using UnityEngine;

namespace BattleCity.AI.Pathfinding
{
    public class FieldContainerComponent : MonoBehaviour
    {
        [Header("Field settings")]
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private GameObject[] _walls;
        
        [Header("Coordinates converting settings")]
        [SerializeField] private Vector3 _topLeftPointPosition;
        [SerializeField] private float _distanceBetweenPoints;
        
        public FieldContainer FieldContainer { get; private set; }

        private void Awake()
        {
            FieldContainer = new FieldContainer(
                _rows,
                _columns,
                _walls,
                _topLeftPointPosition,
                _distanceBetweenPoints
                );
        }
    }
}