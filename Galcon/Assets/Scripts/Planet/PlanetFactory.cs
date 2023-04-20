﻿using System;
using UnityEngine;

public class PlanetFactory : IPlanetFactory
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
    private IPrefabProvider _prefabProvider;

    public PlanetFactory(Settings settings, IPrefabProvider prefabProvider)
    {
        _settings = settings;
        _prefabProvider = prefabProvider;
    }

    public Planet Create()
    {
        var radius = RandomRadius();
        var shipAmount = RandomShipAmount();

        var model = new Planet(radius, shipAmount);
        CreateController(model);

        return model;
    }

    public Planet Create(int shipsAmount, Player player)
    {
        var radius = RandomRadius();

        var model = new Planet(radius, shipsAmount, player);
        CreateController(model);

        return model;
    }

    public void CreateController(Planet model)
    {
        var prefab = _prefabProvider.Load<PlanetController>(PrefabPath.Planet);
        var planet = UnityEngine.Object.Instantiate(prefab);
        
        planet.OnCreate(model);
    }

    private float RandomRadius()
    {
        var radius = UnityEngine.Random.Range(_settings.minRadius, _settings.maxRadius);
        return radius;
    }

    private int RandomShipAmount()
    {
        var amount = UnityEngine.Random.Range(_settings.minAmount, _settings.maxAmount);
        return amount;
    }
}