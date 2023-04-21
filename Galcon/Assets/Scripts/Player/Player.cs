using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private Color _color;
    private List<Planet> _planets;

    public Color Color => _color;
    public int NumberOfPlanets => _planets.Count;

    public Player(Color color)
    {
        _color = color;
        _planets = new List<Planet>();
    }

    public void AddPlanet(Planet planet)
    {
        if (!HasPlanet(planet))
            _planets.Add(planet);
    }

    public void RemovePlanet(Planet planet)
    {
        if(HasPlanet(planet))
            _planets.Remove(planet);
    }

    public bool HasPlanet(Planet planet)
    {
        return _planets.Contains(planet);
    }
}