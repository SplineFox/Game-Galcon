using TMPro;
using UnityEngine;

public class PlanetView : MonoBehaviour
{
    [SerializeField] private Color _outlineColor;

    [SerializeField] private TextMeshPro _counterText;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _selectionRenderer;
    [SerializeField] private LineRenderer _lineRenderer;

    private void Start()
    {
        HideSelection();
        HideDirection();
    }

    public void SetRadius(float radius)
    {
        var diameter = radius * 2;
        transform.localScale = Vector3.one * diameter;
    }

    public void SetCounter(string text)
    {
        _counterText.text = text;
    }
    
    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public void ShowSelection()
    {
        _selectionRenderer.enabled = true;
    }

    public void HideSelection()
    {
        _selectionRenderer.enabled = true;
    }

    public void ShowDirection()
    {
        _lineRenderer.enabled = true;
    }

    public void SetDirection(Vector2 fromPosition, Vector2 toPosition)
    {
        _lineRenderer.positionCount = 2;

        _lineRenderer.SetPosition(0, fromPosition);
        _lineRenderer.SetPosition(1, toPosition);

        _lineRenderer.startColor = _outlineColor;
        _lineRenderer.endColor = _outlineColor;
    }

    public void HideDirection()
    {
        _lineRenderer.enabled = false;
    }
}