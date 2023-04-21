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

        SetPosition();
        SetRotation();
        SetColor();
    }

    private void OnDestroy()
    {
        _model.DeleteRequested -= OnDeleteRequested;
    }

    private void FixedUpdate()
    {
        if (_model != null)
        {
            UpdatePosition();
            UpdateRotation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlanetController>(out var planet))
        {
            if (_model.Target == planet.Model)
                _model.OnTargetReached();
        }
    }

    private void UpdatePosition()
    {
        Vector2 direction = (_model.Target.Position - _model.Position).normalized;
        Vector2 velocity = direction * _model.Speed * Time.fixedDeltaTime;
        Vector2 position = _rigidbody2D.position + velocity;

        _rigidbody2D.MovePosition(position);
        _model.SetPosition(_rigidbody2D.position);
    }

    private void UpdateRotation()
    {
        Vector2 direction = (_model.Position - _model.PreviousPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 4f * Time.fixedDeltaTime);
    }

    private void SetPosition()
    {
        transform.position = _model.Position;
    }

    private void SetRotation()
    {
    }

    private void SetColor()
    {
        _view.SetColor(_model.Owner.Color);
    }

    private void OnDeleteRequested()
    {
        Destroy(gameObject);
    }
}