using System;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : IPlanetSpawner
{
    [Serializable]
    public class Settings
    {
        public int PlanetsToSpawn;
        public float MinOffset;
    }

    private readonly Settings _settings;
    private readonly ILevelArea _area;
    private readonly IPlanetFactory _factory;
    private readonly IPlayersRegistry _playersRegistry;

    private List<Planet> _planets;

    public PlanetSpawner(Settings settings, ILevelArea area, IPlanetFactory factory, IPlayersRegistry playersRegistry)
    {
        _settings = settings;
        _area = area;
        _factory = factory;
        _playersRegistry = playersRegistry;

        _planets = new List<Planet>();
    }

    public void Generate()
    {
        for (int planetIndex = 0; planetIndex < _settings.PlanetsToSpawn; planetIndex++)
        {
            SpawnPlanet();
        }
        AssignPlayers();
    }

    private void SpawnPlanet()
    {
        var planet = _factory.Create();
        var position = FindPositionForPlanet(planet);

        planet.SetPosition(position);
        _planets.Add(planet);
    }

    private void AssignPlayers()
    {
        var planetIndex = UnityEngine.Random.Range(0, _planets.Count);
        var planet = _planets[planetIndex];
        planet.SetOwner(_playersRegistry.MainPlayer);
        planet.SetShipCount(50);
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
            var minOffset = radiusSum + _settings.MinOffset;

            if (distance < minOffset)
                return false;
        }

        return true;
    }
}