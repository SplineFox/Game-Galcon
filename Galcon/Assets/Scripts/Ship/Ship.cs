using System;
using UnityEngine;

public class Ship
{
    public Vector2 PreviousPosition { get; private set; }
    public Vector2 Position { get; private set; }
    public float Speed { get; }
    public Player Owner { get; }
    public Planet Target { get; }


    public event Action DeleteRequested = delegate { };


    public Ship(Vector2 position, float speed, Player owner, Planet target)
    {
        PreviousPosition = position;
        Position = position;
        Speed = speed;
        Target = target;
        Owner = owner;
    }

    public void SetPosition(Vector2 position)
    {
        PreviousPosition = Position;
        Position = position;
    }

    public void OnTargetReached()
    {
        Target.HandleShip(this);
        Delete();
    }

    public void Delete()
    {
        DeleteRequested.Invoke();
    }

}