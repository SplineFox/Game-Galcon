using System;
using UnityEngine;

public class GameInput : IGameInput
{
    private Vector2 _previousMousePosition;
    private Vector2 _currentMousePosition;

    public event Action<Vector2> MouseMove = delegate { };
    public event Action<Vector2> MouseDown = delegate { };
    public event Action<Vector2> MouseUp = delegate { };

    public GameInput()
    {
        _currentMousePosition = Input.mousePosition;
        _previousMousePosition = _currentMousePosition;
    }

    public void Tick()
    {
        CheckMouseMove();
        CheckMouseDown();
        CheckMouseUp();
    }

    private void CheckMouseMove()
    {
        _currentMousePosition = Input.mousePosition;
        if (_currentMousePosition != _previousMousePosition)
        {
            _previousMousePosition = _currentMousePosition;
            MouseMove.Invoke(_currentMousePosition);
        }
    }

    private void CheckMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
            MouseDown.Invoke(_currentMousePosition);
    }

    private void CheckMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
            MouseUp.Invoke(_currentMousePosition);
    }
}