using System;
using UnityEngine;

public class BootstrapState : IGameState
{
    private readonly GameStateMachine _stateMachine;
    private readonly DIContainer _diContainer;
    private readonly GameSettings _gameSettings;

    public BootstrapState(GameStateMachine stateMachine, DIContainer diContainer, GameSettings gameSettings)
    {
        _stateMachine = stateMachine;
        _diContainer = diContainer;
        _gameSettings = gameSettings;

        RegisterBaseServices();
        RegisterLevelServices();
        RegisterFactories();
        RegisterSpawners();
        RegisterGameServices();
    }

    public void Enter()
    {
        _stateMachine.Enter<PrepareLevelState>();
    }

    public void Exit()
    {
    }

    private void RegisterBaseServices()
    {
        _diContainer.Register<IPrefabProvider>(new PrefabProvider());
    }

    private void RegisterLevelServices()
    {
        _diContainer.Register<ILevelArea>(new LevelArea(
            _gameSettings.LevelAreaSettings,
            Camera.main));

        _diContainer.Register<IPlayersRegistry>(new PlayersRegistry(
            _gameSettings.PlayersRegistrySettings));
    }

    private void RegisterFactories()
    {
        _diContainer.Register<IPlanetFactory>(new PlanetFactory(
            _gameSettings.PlanetFactorySettings,
            _diContainer.Resolve<IPrefabProvider>()));

        _diContainer.Register<IShipFactory>(new ShipFactory(
            _gameSettings.ShipFactorySettings,
            _diContainer.Resolve<IPrefabProvider>()));
    }

    private void RegisterSpawners()
    {
        _diContainer.Register<IPlanetSpawner>(new PlanetSpawner(
            _gameSettings.PlanetSpawnerSettings,
            _diContainer.Resolve<ILevelArea>(),
            _diContainer.Resolve<IPlanetFactory>(),
            _diContainer.Resolve<IPlayersRegistry>()));

        _diContainer.Register<IShipSpawner>(new ShipSpawner(
            _gameSettings.ShipSpawnerSettings,
            _diContainer.Resolve<IShipFactory>()));
    }

    private void RegisterGameServices()
    {
        _diContainer.Register<ITargetManager>(new TargetManager(
            _diContainer.Resolve<IPlayersRegistry>(),
            _diContainer.Resolve<IShipSpawner>()));

        _diContainer.Register<IGameFactory>(new GameFactory(
            _diContainer.Resolve<IGameInput>(),
            _diContainer.Resolve<IPrefabProvider>(),
            _diContainer.Resolve<ITargetManager>()));
    }
}