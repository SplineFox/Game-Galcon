using System;

public class ShipFactory : IShipFactory
{
    [Serializable]
    public class Settings
    {
        public int ShipSpeed;
    }

    private Settings _settings;
    private IPrefabProvider _prefabProvider;

    public ShipFactory(Settings settings, IPrefabProvider prefabProvider)
    {
        _settings = settings;
        _prefabProvider = prefabProvider;
    }

    public Ship Create(Player owner, Planet target)
    {
        var ship = new Ship(_settings.ShipSpeed, owner, target);
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