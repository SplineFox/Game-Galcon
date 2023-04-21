using UnityEngine;

public interface IShipFactory
{
    public Ship Create(Vector2 position, Player owner, Planet target);
}