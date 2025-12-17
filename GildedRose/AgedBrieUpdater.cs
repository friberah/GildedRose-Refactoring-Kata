namespace GildedRoseKata;

public class AgedBrieUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        item.SellIn = item.SellIn - 1;
        if (item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.SellIn < 0 && item.Quality < 50) item.Quality = item.Quality + 1;
    }
}