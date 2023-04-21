using UnityEngine;

public class GameFactory : IGameFactory
{
    private readonly IGameInput _gameInput;
    private readonly IPrefabProvider _prefabProvider;
    private readonly ITargetManager _targetManager;

    private Transform _selectionCanvas;
    private SelectionBox _selectionBox;
    private PlanetSelector _planetSelector;

    public GameFactory(IGameInput gameInput, IPrefabProvider prefabProvider, ITargetManager targetManager)
    {
        _gameInput = gameInput;
        _prefabProvider = prefabProvider;
        _targetManager = targetManager;
    }

    public void CreateSelectionCanvas()
    {
        var selectionCanvasPrefab = _prefabProvider.Load<GameObject>(PrefabPath.SelectionCanvas);
        var selectionCanvas = Object.Instantiate(selectionCanvasPrefab);
        _selectionCanvas = selectionCanvas.transform;
    }

    public void CreateSelectionBox()
    {
        var selectionBoxPrefab = _prefabProvider.Load<SelectionBox>(PrefabPath.SelectionBox);
        var selectionBox = Object.Instantiate(selectionBoxPrefab, _selectionCanvas);
        _selectionBox = selectionBox;
    }

    public void CreatePlanetSelector()
    {
        _planetSelector = new PlanetSelector(_gameInput, _selectionBox, _targetManager);
    }
}