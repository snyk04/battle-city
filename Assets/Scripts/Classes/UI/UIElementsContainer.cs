using UnityEngine;

namespace BattleCity.UI
{
    public class UIElementsContainer
    {
        private readonly GameObject[] _uIElements;

        private bool _isActive;
        
        public UIElementsContainer(GameObject[] uIElements, bool isActiveByDefault)
        {
            _uIElements = uIElements;
            
            _isActive = isActiveByDefault;
            ChangeElementsActiveness(_isActive);
        }

        public void SwitchElementsActiveness()
        {
            _isActive = !_isActive;
            
            ChangeElementsActiveness(_isActive);
        }

        private void ChangeElementsActiveness(bool isActive)
        {
            foreach (GameObject uIElement in _uIElements)
            {
                uIElement.SetActive(isActive);
            }
        }
    }
}