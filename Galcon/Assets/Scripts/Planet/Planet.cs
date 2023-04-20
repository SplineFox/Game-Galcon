using System;
using UnityEngine;

public class Planet
{
    public Vector2 Position { get; private set; }
    public float Radius { get; }
    public int ShipsCount { get; private set; }
    public Player Owner { get; }


    private float _timeTillProduce;


    public event Action ShipsCountChanged = delegate { };
    public event Action PositionChanged = delegate { };
    public event Action DeleteRequested = delegate { };


    public Planet(float radius, int shipsCount, Player owner = null)
    {
        Radius = radius;
        ShipsCount = shipsCount;
        Owner = owner;
    }

    public void Tick(float deltaTime)
    {
        if(Owner != null)
        {
            if (_timeTillProduce <= 0)
                ProduceShips();

            _timeTillProduce -= deltaTime;
        }
    }

    public void TakeShips(int shipsAmount)
    {
        SetShipCount(ShipsCount - shipsAmount);
    }

    public void SetPosition(Vector2 position)
    {
        Position = position;
        PositionChanged.Invoke();
    }

    public void Delete()
    {
        DeleteRequested.Invoke();
    }

    private void SetShipCount(int shipsCount)
    {
        if (ShipsCount == shipsCount)
            return;

        ShipsCount = Math.Max(0, shipsCount);
        ShipsCountChanged.Invoke();
    }

    private void ProduceShips()
    {
        SetShipCount(ShipsCount + 5);
    }
}