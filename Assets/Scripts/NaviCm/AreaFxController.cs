using UnityEngine;

namespace NaviCm
{
    public class AreaFxController : MonoBehaviour
    {
        [SerializeField] private ActiveArea activeArea;
    
        private GameObject _activeAreaLight;
        private ParticleSystem _activeAreaParticles;

        private void Awake() => activeArea.evUpdateActiveArea.AddListener(UpdateAreaLight);
        private void OnDestroy() => activeArea.evUpdateActiveArea.RemoveListener(UpdateAreaLight);
    
        private void UpdateAreaLight(Area area)
        {
            if (area)
            {
                _activeAreaLight = area.AreaLight;
                _activeAreaParticles = area.ParticleSystem;
                _activeAreaParticles.Play();
                _activeAreaLight.SetActive(true);
            }
            else
            {
                _activeAreaLight.SetActive(false);
                _activeAreaParticles.Stop();
            }
        }

        public void TurnOffActiveLight()
        {
            _activeAreaLight?.SetActive(false);
            _activeAreaParticles?.Stop();
        }
    }
}
