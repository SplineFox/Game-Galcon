using TMPro;
using UnityEngine;

public class PlanetView : MonoBehaviour
{
    [SerializeField] private Color _outlineColor;
    [SerializeField] private Sprite[] _sprites;

    [SerializeField] private TextMeshPro _counterText;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _selectionRenderer;

    private void Start()
    {
        _selectionRenderer.color = _outlineColor;
        _selectionRenderer.enabled = false;

        SetRandomSprite();
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

    private void SetRandomSprite()
    {
        int spriteIndex = Random.Range(0, _sprites.Length);
        Sprite sprite = _sprites[spriteIndex];
        
        _spriteRenderer.sprite = sprite;
    }
}