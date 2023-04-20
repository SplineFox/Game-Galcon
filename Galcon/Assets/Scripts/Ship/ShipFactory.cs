using System;

public class ShipFactory : IShipFactory
{
    [Serializable]
    public class Settings
    {
        public int ShipSpeed;
    }

    private Settings _settings;
    private PrefabProvider _prefabProvider;

    public ShipFactory(Settings settings, PrefabProvider prefabProvider)
    {
        _settings = settings;
        _prefabProvider = prefabProvider;
    }

    public Ship Create(Planet target, Player player)
    {
        var ship = new Ship(_settings.ShipSpeed, target, player);
        CreateController(ship);

        return ship;
    }

    private void CreateController(Ship model)
    {
        var prefab = _prefabProvider.Load<ShipController>(PrefabPath.Ship);
        var ship = UnityEngine.Object.Instantiate(prefab);

        ship.OnCreate(model);
    }
}