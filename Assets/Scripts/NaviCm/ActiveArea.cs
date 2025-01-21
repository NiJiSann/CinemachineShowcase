using UnityEngine;
using UnityEngine.Events;

namespace NaviCm
{
    public class ActiveArea : MonoBehaviour
    {
        [SerializeField] private GameState gameState;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float maxDistance;
    
        private Area _currentArea;
        private Camera _camera;
    
        [HideInInspector] public UnityEvent<Area> evUpdateActiveArea;
    
        private void Start()
        {
            _camera = Camera.main!;
        }

        private void Update()
        {
            if (gameState.State != GameStates.World) return;
        
            var mousePosition = Input.mousePosition;
            var mouseWorldPosition = _camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, maxDistance));
            var direction = (mouseWorldPosition - _camera.transform.position).normalized;

            Debug.DrawRay(_camera.transform.position, direction * maxDistance, Color.blue);

            if (Physics.Raycast(_camera.transform.position, direction, out var hit, maxDistance, layerMask))
            {
                if (_currentArea) return;
                if (!hit.collider.TryGetComponent(out Area area)) return;
            
                _currentArea = area;
                evUpdateActiveArea?.Invoke(_currentArea);
            }
            else if (_currentArea)
            {
                _currentArea = null;
                evUpdateActiveArea?.Invoke(_currentArea);
            }
        
        }
    }
}
