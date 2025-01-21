using UnityEngine;

namespace NaviCm
{
    public class AreaLightController : MonoBehaviour
    {
        [SerializeField] private ActiveArea activeArea;
    
        private GameObject _activeAreaLight;

        private void Awake() => activeArea.evUpdateActiveArea.AddListener(UpdateAreaLight);
        private void OnDestroy() => activeArea.evUpdateActiveArea.RemoveListener(UpdateAreaLight);
    
        private void UpdateAreaLight(Area area)
        {
            if (area)
            {
                _activeAreaLight = area.AreaLight;
                _activeAreaLight.SetActive(true);
            }
            else
            {
                _activeAreaLight.SetActive(false);
            }
        }

        public void TurnOffActiveLight()
        {
            _activeAreaLight?.SetActive(false);
        }
    }
}
