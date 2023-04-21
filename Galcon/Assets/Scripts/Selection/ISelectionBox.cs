using UnityEngine;

public interface ISelectionBox
{
    public Vector2 StartPosition { get; }
    public Vector2 EndPosition { get; }

    public void SetStart(Vector2 startPosition);
    public void SetEnd(Vector2 endPosition);
    public void Show();
    public void Hide();
}