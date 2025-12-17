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
        var updater = new SulfurasUpdater();
        updater.Update(item);
    }

    private static void UpdateAgedBrie(Item item)
    {
        var updater = new AgedBrieUpdater();
        updater.Update(item);
    }

    private static void UpdateBackstagePasses(Item item)
    {
        var updater = new BackstagePassUpdater();
        updater.Update(item);
    }
    
    private static void  UpdateNormalItem(Item item)
    {
        var updater = new StandardItemUpdater();
        updater.Update(item);
    }
}