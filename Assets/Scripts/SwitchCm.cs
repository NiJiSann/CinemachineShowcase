using UnityEngine;
using UnityEngine.UI;

public class SwitchCm : MonoBehaviour
{
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;
    [SerializeField] private GameObject[] cameras;
    
    private int _currentCameraIndex;

    private void Start()
    {
        buttonLeft.onClick.AddListener(() => SwitchToCamera(-1));
        buttonRight.onClick.AddListener(() => SwitchToCamera(+1));
    }

    private void SwitchToCamera(int increment)
    {
        var previousCineMachineCamera = cameras[_currentCameraIndex];
        _currentCameraIndex = ClampedCameraIndex(_currentCameraIndex + increment);
        cameras[_currentCameraIndex].SetActive(true);
        previousCineMachineCamera.SetActive(false);;
    }
    
    private int ClampedCameraIndex(int cameraIndex)
    {
        var mod = cameraIndex % cameras.Length;
        return mod < 0 ? cameras.Length + mod : mod;
    }
}
