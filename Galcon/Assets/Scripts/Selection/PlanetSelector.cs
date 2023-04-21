using System;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelector : IDisposable
{
    private readonly IGameInput _gameInput;
    private readonly ISelectionBox _selectionBox;
    private readonly ITargetManager _targetManager;
    private bool _isSelecting;

    public PlanetSelector(IGameInput gameInput, ISelectionBox selectionBox, ITargetManager selectionManager)
    {
        _gameInput = gameInput;
        _selectionBox = selectionBox;
        _targetManager = selectionManager;

        _isSelecting = false;

        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _gameInput.MouseDown += OnMouseDown;
        _gameInput.MouseMove += OnMouseMove;
        _gameInput.MouseUp += OnMouseUp;
    }

    private void Unsubscribe()
    {
        _gameInput.MouseDown -= OnMouseDown;
        _gameInput.MouseMove -= OnMouseMove;
        _gameInput.MouseUp -= OnMouseUp;
    }

    private void OnMouseDown(Vector2 mouseScreenPosition)
    {
        StartSelection(mouseScreenPosition);
    }

    private void OnMouseMove(Vector2 mouseScreenPosition)
    {
        UpdateSelection(mouseScreenPosition);
    }

    private void OnMouseUp(Vector2 mouseScreenPosition)
    {
        FinishSelection();
    }

    private void StartSelection(Vector2 mouseScreenPosition)
    {
        _isSelecting = true;
        _selectionBox.Show();
        _selectionBox.SetStart(mouseScreenPosition);
    }

    private void UpdateSelection(Vector2 mouseScreenPosition)
    {
        if(_isSelecting)
            _selectionBox.SetEnd(mouseScreenPosition);
    }

    private void FinishSelection()
    {
        _isSelecting = false;
        _selectionBox.Hide();

        var planets = GetSelectionOverlaps();
        ManageSelections(planets);
    }

    private List<Planet> GetSelectionOverlaps()
    {
        var worldStartPosition = Camera.main.ScreenToWorldPoint(_selectionBox.StartPosition);
        var worldEndPosition = Camera.main.ScreenToWorldPoint(_selectionBox.EndPosition);
        var colliders = Physics2D.OverlapAreaAll(worldStartPosition, worldEndPosition);

        var planets = new List<Planet>();
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<PlanetController>(out var planet))
            {
                    planets.Add(planet.Model);
            }
        }
        return planets;
    }

    private void ManageSelections(List<Planet> planets)
    {
        if(planets.Count == 1)
        {
            _targetManager.Select(planets[0]);
            return;
        }

        if (planets.Count > 1)
        {
            _targetManager.SelectMultiple(planets);
            return;
        }

        _targetManager.DeselectAll();
    }
}