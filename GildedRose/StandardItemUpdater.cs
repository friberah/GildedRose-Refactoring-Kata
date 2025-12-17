namespace GildedRoseKata;

public class StandardItemUpdater
{
    public void UpdateQueality(Item item)
    {
        item.SellIn = item.SellIn - 1;
        if (item.Quality > 0) item.Quality = item.Quality - 1;
        if (item.SellIn < 0 && item.Quality > 0 ) item.Quality = item.Quality - 1;
    }
}