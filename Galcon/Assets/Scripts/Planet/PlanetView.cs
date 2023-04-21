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
        _selectionRenderer.color = _outlineColor;
        _lineRenderer.startColor = _outlineColor;
        _lineRenderer.endColor = _outlineColor;

        HideSelection();
        HideDirection();
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void SetRadius(float radius)
    {
        var diameter = radius * 2;
        transform.localScale = Vector2.one * diameter;
    }

    public void SetCounter(string text)
    {
        _counterText.text = text;
    }
    
    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public void SetSelection(bool isSelected)
    {
        _selectionRenderer.enabled = isSelected;
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
    }

    public void HideDirection()
    {
        _lineRenderer.enabled = false;
    }
}