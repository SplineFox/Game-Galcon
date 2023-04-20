public class PlanetModel
{
    public float Radius { get; }
    public int ShipsCount { get; set; }
    public Player Owner { get; }

    public PlanetModel(float radius, int shipsCount, Player owner = null)
    {
        ShipsCount = shipsCount;
        Radius = radius;
        Owner = owner;
    }
}