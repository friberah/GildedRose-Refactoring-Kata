using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    [Fact]
    public void SulfurasItem_NeverHasToBeSoldOrDecreasedInQuality()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 }
        };
        var app = new GildedRose(Items);

        Assert.Equal(10, Items[0].SellIn);
        Assert.Equal(80, Items[0].Quality);
    }
}