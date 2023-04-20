using System;
using UnityEngine;

public class Ship
{
    public Vector2 Position { get; private set; }
    public float Speed { get; }
    public Player Owner { get; }
    public Planet Target { get; }


    public event Action DeleteRequested = delegate { };


    public Ship(float speed, Player owner, Planet target)
    {
        Speed = speed;
        Target = target;
        Owner = owner;
    }

    public void SetPosition(Vector2 position)
    {
        Position = position;
    }

    public void Delete()
    {
        DeleteRequested.Invoke();
    }

}