using System;
using UnityEngine;

public interface IGameInput
{
    event Action<Vector2> MouseMove;
    event Action<Vector2> MouseDown;
    event Action<Vector2> MouseUp;
}