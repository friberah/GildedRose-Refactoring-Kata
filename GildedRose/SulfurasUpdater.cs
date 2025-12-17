namespace GildedRoseKata;

public class SulfurasUpdater
{
    public void UpdateQuality(Item item)
    {
        // Just in case it is passed with wrong quality
        item.Quality = 80;
    }
}