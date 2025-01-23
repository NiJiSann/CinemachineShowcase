using UnityEngine;

namespace NaviCm
{
    public class Area : MonoBehaviour
    {
        [SerializeField] private GameObject areaCamera;
        [SerializeField] private GameObject areaLight;
        [SerializeField] private ParticleSystem particles;
    
        public GameObject AreaCamera => areaCamera;
        public GameObject AreaLight => areaLight;
        public ParticleSystem ParticleSystem => particles;
    }
}
