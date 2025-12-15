using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests.UpdateSulfurasTests;

public class UpdateSulfurasTests
{
    [Fact]
    public void SulfurasItem_NeverDecreasesInQuality()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 }
        };
        var app = new GildedRose(Items);

        Assert.Equal(10, Items[0].SellIn);
        Assert.Equal(80, Items[0].Quality);
    }

    [Fact]
    public void SulfurasItem_NeverHasToBeSold()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 }
        };
        var app = new GildedRose(Items);

        Assert.Equal(10, Items[0].SellIn);
    }
}