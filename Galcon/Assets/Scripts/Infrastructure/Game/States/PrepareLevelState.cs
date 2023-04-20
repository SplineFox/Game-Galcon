using UnityEngine;

public class PrepareLevelState : IGameState
{
    private readonly GameStateMachine _stateMachine;
    private readonly IPlanetSpawner _planetSpawner;

    public PrepareLevelState(GameStateMachine stateMachine, IPlanetSpawner planetSpawner)
    {
        _stateMachine = stateMachine;
        _planetSpawner = planetSpawner;
    }

    public void Enter()
    {
        _planetSpawner.Generate();

        _stateMachine.Enter<GameLoopState>();
    }

    public void Exit()
    {
    }
}