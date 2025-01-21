using UnityEngine;

namespace NaviCm
{
    public class Area : MonoBehaviour
    {
        [SerializeField] private GameObject areaCamera;
        [SerializeField] private GameObject areaLight;
    
        public GameObject AreaCamera => areaCamera;
        public GameObject AreaLight => areaLight;
    }
}
