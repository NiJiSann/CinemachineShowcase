using UnityEngine;

namespace NaviCm
{
    public class Area : MonoBehaviour
    {
        [SerializeField] private GameObject areaCamera;
        [SerializeField] private AreaFx[] _areaFxs;
        
        public GameObject AreaCamera => areaCamera;
        public AreaFx[] AreaFxes  => _areaFxs;
    }
}
