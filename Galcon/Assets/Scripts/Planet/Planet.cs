using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    private PlanetView _view;
    private PlanetModel _model;

    private float _timeTillCreation;

    public void Construct(PlanetModel model)
    {
        _model = model;
    }

    private void Start()
    {
        _view.SetRadius(_model.Radius);
        _view.SetColor(_model.Owner.Color);
    }

    private void Update()
    {
        if (_model.Owner != null)
            ProduceShips();
    }

    private void ProduceShips()
    {
        if(_timeTillCreation <= 0)
        {
            _model.ShipsCount += 5;
            _timeTillCreation = 1f;
        }
        _timeTillCreation -= Time.deltaTime;
    }

    public bool IsSelectableBy(Player player)
    {
        return _model.Owner == player;
    }

    public void Select()
    {
        _view.ShowSelection();
    }

    public void Deselect()
    {
        _view.HideSelection();
    }

    public void SetDirection(Planet planet)
    {
        Vector2 fromPosition = transform.position;
        Vector2 toPosition = planet.transform.position;

        _view.SetDirection(fromPosition, toPosition);
        _view.ShowDirection();
    }

    public void ResetDirection()
    {
        _view.HideDirection();
    }
}