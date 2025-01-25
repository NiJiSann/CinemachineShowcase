using UnityEngine;

namespace NaviCm
{
    public class AreaFxController : MonoBehaviour
    {
        [SerializeField] private ActiveArea activeArea;

        private AreaFx[] _areaFxs;
        
        private void Awake() => activeArea.evUpdateActiveArea.AddListener(UpdateAreaLight);
        private void OnDestroy() => activeArea.evUpdateActiveArea.RemoveListener(UpdateAreaLight);
    
        private void UpdateAreaLight(Area area)
        {
            if (area)
            {
                _areaFxs = area.AreaFxes;

                foreach (var areaFx in _areaFxs)
                    areaFx.Play();
            }
            else
            {
                foreach (var areaFx in _areaFxs)
                    areaFx.Stop();
            }
        }

        public void TurnOffAllFx()
        {
            foreach (var areaFx in _areaFxs)
                areaFx.Stop();
        }
    }
}
