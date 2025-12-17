namespace GildedRoseKata;

public class SulfurasUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        // Just in case it is passed with wrong quality
        item.Quality = 80;
    }
}