using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros") UpdateSulfuras(item);
            else if (item.Name == "Aged Brie") UpdateAgedBrie(item);
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert") UpdateBackstagePasses(item);
            else UpdateNormalItem(item);
        }
    }
    private static void UpdateSulfuras(Item item)
    {
        return;
    }

    private static void UpdateAgedBrie(Item item)
    {
        item.SellIn = item.SellIn - 1;
        if (item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.SellIn < 0 && item.Quality < 50) item.Quality = item.Quality + 1;
    }

    private static void UpdateBackstagePasses(Item item)
    {
        if (item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.SellIn < 11 && item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.SellIn < 6 && item.Quality < 50) item.Quality = item.Quality + 1;
        if (item.SellIn <= 0) item.Quality = item.Quality - item.Quality;
        
        item.SellIn = item.SellIn - 1;
    }
    
    private static void  UpdateNormalItem(Item item)
    {
        var updater = new StandardItemUpdater();
        updater.UpdateQueality(item);
    }
}