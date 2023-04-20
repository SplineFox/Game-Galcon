public interface IPlanetFactory
{
    public Planet Create();
    public Planet Create(int shipsAmount, Player player);
}