using System;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : IPlanetSpawner
{
    [Serializable]
    public class Settings
    {
        public int PlanetsToSpawn;
    }

    private readonly Settings _settings;
    private readonly ILevelArea _area;
    private readonly IPlanetFactory _factory;

    private List<Planet> _planets;

    public PlanetSpawner(Settings settings, ILevelArea area, IPlanetFactory factory)
    {
        _settings = settings;
        _area = area;
        _factory = factory;
    }

    public void Generate()
    {
    }

    private void Spawn()
    {
        var planet = _factory.Create();
        var position = FindPositionForPlanet(planet);

        planet.SetPosition(position);

        _planets.Add(planet);
    }

    private Vector2 FindPositionForPlanet(Planet planet)
    {
        Vector2 positionToSpawn;

        do
        {
            positionToSpawn = GetRandomPosition();
        }
        while (!PositionIsValid(planet, positionToSpawn));

        return positionToSpawn;
    }

    private Vector2 GetRandomPosition()
    {
        var x = UnityEngine.Random.Range(_area.Left, _area.Right);
        var y = UnityEngine.Random.Range(_area.Bottom, _area.Top);

        return new Vector2(x, y);
    }

    private bool PositionIsValid(Planet newPlanet, Vector2 newPosition)
    {
        foreach (var planet in _planets)
        {
            var distance = Vector2.Distance(planet.Position, newPosition);
            var radiusSum = planet.Radius + newPlanet.Radius;

            if (distance < radiusSum)
                return false;
        }

        return true;
    }
}