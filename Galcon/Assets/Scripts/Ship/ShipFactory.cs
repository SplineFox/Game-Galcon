using System;
using UnityEngine;

public class ShipFactory : IShipFactory
{
    [Serializable]
    public class Settings
    {
        [Range(0.2f, 2f)]
        public float ShipSpeed;
    }

    private Settings _settings;
    private IPrefabProvider _prefabProvider;

    public ShipFactory(Settings settings, IPrefabProvider prefabProvider)
    {
        _settings = settings;
        _prefabProvider = prefabProvider;
    }

    public Ship Create(Vector2 position, Player owner, Planet target)
    {
        var ship = new Ship(position, _settings.ShipSpeed, owner, target);
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