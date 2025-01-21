using UnityEngine;
using UnityEngine.UI;

namespace SwitchCm
{
    internal enum Switch
    {
        Left = -1,
        Right = 1,
    }

    public class SwitchCm : MonoBehaviour
    {
        [SerializeField] private Button buttonLeft;
        [SerializeField] private Button buttonRight;
        [SerializeField] private GameObject[] cameras;
    
        private int _currentCameraIndex;
        private CameraSwitch _cameraSwitch;
    
        private void Awake() => _cameraSwitch = new CameraSwitch(cameras);
    
        private void Start()
        {
            buttonLeft.onClick.AddListener(() => _cameraSwitch.SwitchToCamera((int)Switch.Left));
            buttonRight.onClick.AddListener(() => _cameraSwitch.SwitchToCamera((int)Switch.Right));
        }
    }
}