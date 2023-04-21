using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class SelectionBox : MonoBehaviour, ISelectionBox
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _image;

    private Vector2 _startPosition;
    private Vector2 _endPosition;

    Vector2 ISelectionBox.StartPosition => _startPosition;
    Vector2 ISelectionBox.EndPosition => _endPosition;

    private void Start()
    {
        Assert.IsNotNull(_rectTransform);
        Assert.IsNotNull(_image);

        _image.enabled = false;
    }

    void ISelectionBox.SetStart(Vector2 startPosition)
    {
        _startPosition = startPosition;
        ResetSelection();
    }

    void ISelectionBox.SetEnd(Vector2 endPosition)
    {
        _endPosition = endPosition;
        ResizeSelection();
    }

    void ISelectionBox.Show()
    {
        _image.enabled = true;
    }

    void ISelectionBox.Hide()
    {
        _image.enabled = false;
    }

    private void ResizeSelection()
    {
        Vector2 sizeDelta = _endPosition - _startPosition;

        _rectTransform.anchoredPosition = _startPosition + sizeDelta / 2;
        _rectTransform.sizeDelta = Vector2Util.Abs(sizeDelta);
    }

    private void ResetSelection()
    {
        _endPosition = _startPosition;
        _rectTransform.sizeDelta = Vector2.zero;
    }
}