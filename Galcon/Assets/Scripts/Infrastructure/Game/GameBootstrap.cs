using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField]
    private GameSettings _gameSettings;

    private DIContainer _diContainer;
    private GameStateMachine _gameStateMachine;
    private GameInput _gameInput;

    private void Awake()
    {
        _diContainer = new DIContainer();
        _gameInput = new GameInput();

        _diContainer.Register<IGameInput>(_gameInput);

        _gameStateMachine = new GameStateMachine(_diContainer, _gameSettings);
        _gameStateMachine.Enter<BootstrapState>();
    }

    private void Update()
    {
        _gameInput.Tick();
    }
}