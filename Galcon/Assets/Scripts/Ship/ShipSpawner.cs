using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : IShipSpawner
{
    [Serializable]
    public class Settings
    {
        [Range(0.1f,1f)]
        public float ShipsPercentage;
        [Tooltip("Radius offset used when arranging ships in spiral")]
        public float SpiralRadiusOffset;
        [Tooltip("Angle offset used when arranging ships in spiral")]
        public float SpiralAngleOffset;
    }

    private readonly Settings _settings;
    private readonly IShipFactory _factory;

    private List<Ship> _ships;

    public ShipSpawner(Settings settings, IShipFactory factory)
    {
        _settings = settings;
        _factory = factory;

        _ships = new List<Ship>();
    }

    public void GenerateSquadron(Planet fromPlanet, Planet toPlanet)
    {
        int shipsToSpawn = (int)(fromPlanet.ShipsCount * _settings.ShipsPercentage);
        fromPlanet.RemoveShips(shipsToSpawn);

        float angle = 0;
        float radius = 0;
        Vector2 position = fromPlanet.Position;

        // Arrange in a spiral
        for (int shipIndex = 0; shipIndex < shipsToSpawn; shipIndex++)
        {
            var x = radius * Mathf.Cos(angle);
            var y = radius * Mathf.Sin(angle);
            position += new Vector2(x,y);

            radius += _settings.SpiralRadiusOffset;
            angle += _settings.SpiralAngleOffset;

            SpawnShip(position, fromPlanet.Owner, toPlanet);
        }
    }

    private void SpawnShip(Vector2 position, Player owner, Planet target)
    {
        var ship = _factory.Create(position, owner, target);
        _ships.Add(ship);
    }
}