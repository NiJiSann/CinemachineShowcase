using Unity.Cinemachine;
using UnityEngine;

public enum GameStates
{
    Area,
    InTransition,
    World
}

public class GameState : MonoBehaviour
{
    [SerializeField] private CinemachineBrain cinemachineBrain;
    
    private GameStates _gameState = GameStates.World;
    public GameStates State
    {
        get => cinemachineBrain.IsBlending ? GameStates.InTransition : _gameState;
        set => _gameState = value;
    }
}
