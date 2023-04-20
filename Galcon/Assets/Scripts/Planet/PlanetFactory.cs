using System;
using UnityEngine;

public class PlanetFactory
{
    [Serializable]
    public class Settings
    {
        public Sprite[] PlanetSprites;
        public float minRadius;
        public float maxRadius;
        public int minAmount;
        public int maxAmount;
    }

    private Settings _settings;
    private PrefabProvider _prefabProvider;

    public PlanetFactory(Settings settings, PrefabProvider prefabProvider)
    {
        _settings = settings;
        _prefabProvider = prefabProvider;
    }

    public Planet Create(int shipsAmount, Player player)
    {
        var prefab = _prefabProvider.Load<Planet>(PrefabPath.Planet);
        var planet = UnityEngine.Object.Instantiate(prefab);

        var model = CreateModel(shipsAmount, player);

        planet.Construct(model);
        return planet;
    }

    private PlanetModel CreateModel(int shipsAmount, Player player)
    {
        var radius = UnityEngine.Random.Range(_settings.minRadius, _settings.maxRadius);
        var model = new PlanetModel(radius, shipsAmount, player);
        return model;
    }
}