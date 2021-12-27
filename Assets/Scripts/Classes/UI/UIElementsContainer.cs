using UnityEngine;

namespace BattleCity.UI
{
    public class UIElementsContainer
    {
        private readonly GameObject[] _uIElements;

        private bool _isActiveByDefault;
        
        public UIElementsContainer(GameObject[] uIElements, bool isActiveByDefault)
        {
            _uIElements = uIElements;
            
            _isActiveByDefault = isActiveByDefault;
            ChangeButtonsActiveness(_isActiveByDefault);
        }

        public void SwitchButtonsActiveness()
        {
            _isActiveByDefault = !_isActiveByDefault;
            
            ChangeButtonsActiveness(_isActiveByDefault);
        }

        private void ChangeButtonsActiveness(bool isActive)
        {
            foreach (GameObject uIElement in _uIElements)
            {
                uIElement.SetActive(isActive);
            }
        }
    }
}