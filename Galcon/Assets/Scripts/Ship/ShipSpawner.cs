using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : IShipSpawner
{
    [Serializable]
    public class Settings
    {
        public float Offset;
        [Range(0.1f,1f)]
        public float ShipsPercentage;
    }

    private readonly Settings _settings;
    private readonly IShipFactory _factory;

    private List<Ship> _ships;

    public ShipSpawner(Settings settings, IShipFactory factory)
    {
        _settings = settings;
        _factory = factory;
    }

    public void GenerateSquadron(Planet fromPlanet, Planet toPlanet)
    {
        int shipsToSpawn = (int)(fromPlanet.ShipsCount * _settings.ShipsPercentage);
        fromPlanet.TakeShips(shipsToSpawn);

        for (int shipIndex = 0; shipIndex < shipsToSpawn; shipIndex++)
        {
            float offset = shipIndex * _settings.Offset;

            Vector2 position = fromPlanet.Position + (Vector2.one * offset);

            SpawnShip(position, fromPlanet.Owner, toPlanet);
        }
    }

    private void SpawnShip(Vector2 position, Player owner, Planet target)
    {
        var ship = _factory.Create(owner, target);
        ship.SetPosition(position);

        _ships.Add(ship);
    }
}