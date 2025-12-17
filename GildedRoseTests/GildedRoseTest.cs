using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    // At the end of each day our system lowers both values for every item
    [Fact]
    public void UpdateQuality_LowersSellInAndQualityForEveryItem()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = 9;
        items[0].SellIn = 9;
    }
}