using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private static Dictionary<string, IItemUpdater> _updaters = new Dictionary<string, IItemUpdater>()
    {
        { "Sulfuras, Hand of Ragnaros", new SulfurasUpdater() },
        { "Aged Brie", new AgedBrieUpdater() },
        { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassUpdater() }
    };
    private static IItemUpdater _defaultUpdater = new StandardItemUpdater();
    
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var updater = _updaters.GetValueOrDefault(item.Name, _defaultUpdater);
            updater.Update(item);
        }
    }
}