using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private ShipView _view;

    private Ship _model;

    public Ship Model => _model;

    public void OnCreate(Ship model)
    {
        _model = model;
        _model.DeleteRequested += OnDeleteRequested;
    }

    private void OnDestroy()
    {
        _model.DeleteRequested -= OnDeleteRequested;
    }

    private void FixedUpdate()
    {
        if (_model != null)
            UpdatePosition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(TryGetComponent<PlanetController>(out var planet))
        {
            if (_model.Target == planet.Model)
                _model.OnTargetReached();
        }
    }

    private void UpdatePosition()
    {
        Vector2 prevPosition = _model.Position;

        Vector2 direction = (_model.Target.Position - _model.Position).normalized;
        Vector2 velocity = direction * _model.Speed * Time.deltaTime;
        Vector2 position = _model.Position + velocity;

        _rigidbody2D.MovePosition(position);
        _model.SetPosition(_rigidbody2D.position);
    }

    private void OnDeleteRequested()
    {
        Destroy(gameObject);
    }
}