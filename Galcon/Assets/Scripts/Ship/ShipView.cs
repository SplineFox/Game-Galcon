using UnityEngine;

public class ShipView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}