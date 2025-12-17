namespace GildedRoseKata;

public class StandardItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        item.SellIn = item.SellIn - 1;
        if (item.Quality > 0) item.Quality = item.Quality - 1;
        if (item.SellIn < 0 && item.Quality > 0 ) item.Quality = item.Quality - 1;
    }
}