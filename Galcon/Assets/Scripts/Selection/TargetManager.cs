using System.Collections.Generic;

public class TargetManager : ITargetManager
{
    private readonly IPlayersRegistry _playersRegistry;
    private readonly IShipSpawner _shipSpawner;

    private List<Planet> _selectedPlanets;

    public TargetManager(IPlayersRegistry playersRegistry, IShipSpawner shipSpawner)
    {
        _playersRegistry = playersRegistry;
        _shipSpawner = shipSpawner;

        _selectedPlanets = new List<Planet>();
    }

    public void Select(Planet planet)
    {
        if(IsTargeting())
        {
            SendShips(planet);
            DeselectAll();
        }
        else
        {
            SelectPlanet(planet);
        }
    }

    public void SelectMultiple(List<Planet> planets)
    {
        for (int index = 0; index < planets.Count; index++)
            SelectPlanet(planets[index]);
    }

    public void DeselectAll()
    {
        for (int index = _selectedPlanets.Count - 1; index >= 0; index--)
            DeselectPlanet(_selectedPlanets[index]);
    }

    private bool IsTargeting()
    {
        return _selectedPlanets.Count > 0;
    }

    private void SelectPlanet(Planet planet)
    {
        if(planet.Owner == _playersRegistry.MainPlayer)
        {
            planet.SetSelection(true);
            _selectedPlanets.Add(planet);
        }
    }

    private void DeselectPlanet(Planet planet)
    {
        if (planet.Owner == _playersRegistry.MainPlayer)
        {
            planet.SetSelection(false);
            _selectedPlanets.Remove(planet);
        }
    }

    private void SendShips(Planet targetPlanet)
    {
        foreach (var planet in _selectedPlanets)
        {
            if(planet != targetPlanet)
                _shipSpawner.GenerateSquadron(planet, targetPlanet);
        }
    }
}