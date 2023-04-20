using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Game-related settings")]
    public LevelArea.Settings LevelAreaSettings;
    
    [Space]
    [Header("Planet-related settings")]
    public PlanetFactory.Settings PlanetFactorySettings;
    public PlanetSpawner.Settings PlanetSpawnerSettings;
    
    [Space]
    [Header("Ship-related settings")]
    public ShipFactory.Settings ShipFactorySettings;
    public ShipSpawner.Settings ShipSpawnerSettings;
}
