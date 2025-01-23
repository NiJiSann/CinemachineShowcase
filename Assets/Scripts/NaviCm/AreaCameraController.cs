using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NaviCm
{
    public class AreaCameraController : MonoBehaviour
    {
        [SerializeField] private GameState gameState;
        [SerializeField] private ActiveArea activeArea;
        [FormerlySerializedAs("areaLightController")] [SerializeField] private AreaFxController areaFxController;
        [SerializeField] private Button backToInitialCamera;
        [SerializeField] private GameObject initialCamera;

        private GameObject _activeAreaCamera;
        private GameObject _hoveredAreaCamera;

        private void Awake()
        {
            activeArea.evUpdateActiveArea.AddListener(UpdateAreaCamera);
            backToInitialCamera.onClick.AddListener(BackToInitialCamera);
            _activeAreaCamera = initialCamera;
        } 
        
        private void OnDestroy() => activeArea.evUpdateActiveArea.RemoveListener(UpdateAreaCamera);

        private void Update()
        {
            if (gameState.State != GameStates.World) return;

            if (Input.GetMouseButtonDown(0) && _hoveredAreaCamera)
            {
                gameState.State = GameStates.Area;
            
                _hoveredAreaCamera.SetActive(true);
                _activeAreaCamera.SetActive(false);
                _activeAreaCamera = _hoveredAreaCamera;
                areaFxController.TurnOffActiveLight();
            }
        }
    
        private void BackToInitialCamera()
        {
            if (gameState.State != GameStates.Area) return;
        
            initialCamera.SetActive(true);
            _activeAreaCamera.SetActive(false);
            _activeAreaCamera = initialCamera;
        
            gameState.State = GameStates.World;
        }
    
        private void UpdateAreaCamera(Area area)
        {
            _hoveredAreaCamera = area ? area.AreaCamera : null;
        }
    }
}
