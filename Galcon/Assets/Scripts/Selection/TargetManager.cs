using System.Collections.Generic;

public class TargetManager : ITargetManager
{
    private readonly Player _player;
    private readonly IShipSpawner _shipSpawner;

    private TargetState _state;
    private List<Planet> _selectedPlanets;

    public TargetManager(Player player, IShipSpawner shipSpawner)
    {
        _player = player;
        _shipSpawner = shipSpawner;

        _state = TargetState.Idling;
        _selectedPlanets = new List<Planet>();
    }

    public void Select(Planet planet)
    {
        switch (_state)
        {
            case TargetState.Idling:
                SelectPlanet(planet);
                _state = TargetState.Targeting;
                break;
            case TargetState.Targeting:
                SendShips(planet);
                DeselectAll();
                _state = TargetState.Idling;
                break;
        }
    }

    public void SelectMultiple(List<Planet> planets)
    {
        foreach (var planet in _selectedPlanets)
            SelectPlanet(planet);

        _state = TargetState.Targeting;
    }

    public void DeselectAll()
    {
        foreach (var planet in _selectedPlanets)
            DeselectPlanet(planet);

        _selectedPlanets.Clear();
        _state = TargetState.Idling;
    }

    private void SelectPlanet(Planet planet)
    {
        planet.SetSelection(true);
    }

    private void DeselectPlanet(Planet planet)
    {
        planet.SetSelection(false);
    }

    private void SendShips(Planet targetPlanet)
    {
        foreach (var planet in _selectedPlanets)
        {
            _shipSpawner.GenerateSquadron(planet, targetPlanet);
        }
    }
}