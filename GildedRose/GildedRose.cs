using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private static readonly Dictionary<string, IItemUpdater> Updaters = new()
    {
        { "Sulfuras, Hand of Ragnaros", new SulfurasUpdater() },
        { "Aged Brie", new AgedBrieUpdater() },
        { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassUpdater() }
    };
    private static readonly IItemUpdater DefaultUpdater = new StandardItemUpdater();
    
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var updater = Updaters.GetValueOrDefault(item.Name, DefaultUpdater);
            updater.Update(item);
        }
    }
}