using System;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField]
    private PlanetView _view;
    private Planet _model;

    public void OnCreate(Planet model)
    {
        _model = model;
        _model.ShipsCountChanged += OnShipsCountChanged;
        _model.PositionChanged += OnPositionChanged;
        _model.DeleteRequested += OnDeleteRequested;
    }

    private void OnDestroy()
    {
        _model.ShipsCountChanged -= OnShipsCountChanged;
        _model.PositionChanged -= OnPositionChanged;
        _model.DeleteRequested -= OnDeleteRequested;
    }

    private void Start()
    {
        _view.SetPosition(_model.Position);
        _view.SetRadius(_model.Radius);
        _view.SetColor(_model.Owner.Color);
    }

    private void Update()
    {
        _model.Tick(Time.deltaTime);
    }

    private void OnShipsCountChanged()
    {
        _view.SetCounter(_model.ShipsCount.ToString());
    }

    private void OnPositionChanged()
    {
        _view.SetPosition(_model.Position);
    }

    private void OnDeleteRequested()
    {
        Destroy(gameObject);
    }
}