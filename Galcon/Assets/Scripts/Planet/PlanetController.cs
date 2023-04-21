using System;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField]
    private PlanetView _view;
    private Planet _model;

    public Planet Model => _model;

    public void OnCreate(Planet model)
    {
        _model = model;

        _model.ShipsCountChanged += OnShipsCountChanged;
        _model.SelectionChanged += OnSelectionChanged;
        _model.PositionChanged += OnPositionChanged;
        _model.OwnerChanged += OnOwnerChanged;
        _model.DeleteRequested += OnDeleteRequested;

        _view.SetPosition(_model.Position);
        _view.SetRadius(_model.Radius);
        _view.SetSelection(_model.IsSelected);
        _view.SetCounter(_model.ShipsCount.ToString());
        _view.SetColor(_model.Owner != null ? _model.Owner.Color : Color.gray);
    }

    private void OnDestroy()
    {
        _model.ShipsCountChanged -= OnShipsCountChanged;
        _model.SelectionChanged -= OnSelectionChanged;
        _model.PositionChanged -= OnPositionChanged;
        _model.OwnerChanged -= OnOwnerChanged;
        _model.DeleteRequested -= OnDeleteRequested;
    }

    private void Update()
    {
        _model?.Tick(Time.deltaTime);
    }

    private void OnShipsCountChanged()
    {
        _view.SetCounter(_model.ShipsCount.ToString());
    }

    private void OnPositionChanged()
    {
        _view.SetPosition(_model.Position);
    }

    private void OnSelectionChanged()
    {
        _view.SetSelection(_model.IsSelected);
    }

    private void OnOwnerChanged()
    {
        _view.SetColor(_model.Owner.Color);
    }

    private void OnDeleteRequested()
    {
        Destroy(gameObject);
    }
}