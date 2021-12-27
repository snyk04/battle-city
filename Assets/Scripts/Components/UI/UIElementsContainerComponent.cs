using UnityEngine;

namespace BattleCity.UI
{
    public class UIElementsContainerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] _uIElements;
        [SerializeField] private bool _isActiveByDefault;
        
        public UIElementsContainer UIElementsContainer { get; private set; }

        private void Awake()
        {
            UIElementsContainer = new UIElementsContainer(_uIElements, _isActiveByDefault);
        }

        public void SwitchButtonsActiveness()
        {
            UIElementsContainer.SwitchButtonsActiveness();
        }
    }
}