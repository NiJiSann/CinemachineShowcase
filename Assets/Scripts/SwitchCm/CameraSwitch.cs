using UnityEngine;

namespace SwitchCm
{
    public class CameraSwitch
    {
        private int _currentCameraIndex;
        private readonly GameObject[] _cameras;

        public CameraSwitch(GameObject[] cameras) => _cameras = cameras;

        public void SwitchToCamera(int increment)
        {
            var previousCineMachineCamera = _cameras[_currentCameraIndex];
            _currentCameraIndex = Utils.CyclicClampIndex(_currentCameraIndex + increment, _cameras.Length);
            _cameras[_currentCameraIndex].SetActive(true);
            previousCineMachineCamera.SetActive(false);;
        }
    }
}
