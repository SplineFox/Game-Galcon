using System;
using System.Collections.Generic;

public class GameStateMachine
{
    private Dictionary<Type, IGameState> _states;
    private IGameState _currentState;

    public GameStateMachine(DIContainer diContainer, GameSettings  gameSettings)
    {
        _currentState = null;
        _states = new Dictionary<Type, IGameState>
        {
            [typeof(BootstrapState)] = new BootstrapState(this, diContainer, gameSettings),
            [typeof(PrepareLevelState)] = new PrepareLevelState(this, diContainer),
            [typeof(GameLoopState)] = new GameLoopState(this),
        };
    }

    public void Enter<TGameState>() where TGameState : IGameState
    {
        _currentState?.Exit();

        var state = _states[typeof(TGameState)];
        _currentState = state;

        _currentState.Enter();
    }
}