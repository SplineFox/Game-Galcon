using UnityEngine;

public class PrepareLevelState : IGameState
{
    private readonly GameStateMachine _stateMachine;

    private readonly IGameFactory _gameFactory;
    private readonly IPlanetSpawner _planetSpawner;

    public PrepareLevelState(GameStateMachine stateMachine, DIContainer diContainer)
    {
        _stateMachine = stateMachine;

        _gameFactory = diContainer.Resolve<IGameFactory>();
        _planetSpawner = diContainer.Resolve<IPlanetSpawner>();
    }

    public void Enter()
    {
        _gameFactory.CreateSelectionCanvas();
        _gameFactory.CreateSelectionBox();
        _gameFactory.CreatePlanetSelector();

        _planetSpawner.Generate();

        _stateMachine.Enter<GameLoopState>();
    }

    public void Exit()
    {
    }
}