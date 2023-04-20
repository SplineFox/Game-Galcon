using System;
using UnityEngine;

public class Ship
{
    public Vector2 Position { get; private set; }
    public float Speed { get; }
    public Planet Target { get; }
    public Player Owner { get; }


    public event Action DeleteRequested = delegate { };


    public Ship(float speed, Planet target, Player owner)
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