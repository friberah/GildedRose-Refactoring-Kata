using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests.UpdateNormalItemTests;

public class UpdateNormalItemTests
{    
    [Fact]
    public void NormalItem_QualityDecreasesBy1_BeforeSellByDate()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Normal Item", SellIn = 5, Quality = 10 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(4, Items[0].SellIn);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void NormalItem_QualityDecreasesByTwo_AfterSellByDate(int sellInDays)
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Normal Item", SellIn = sellInDays, Quality = 10 }
        };

        var app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(8, Items[0].Quality);
    }
    
    // The Quality of an item is never negative
    [Theory]
    [InlineData(1, 0)]
    [InlineData(0, 1)]
    public void NormalItem_QualityNeverDecreasesToNegativeValue(int sellIn, int startingQuality)
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Normal Item", SellIn = 5, Quality = 0 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
      
        Assert.Equal(0, Items[0].Quality);
    }

    [Theory]
    [InlineData(3, 2)]
    [InlineData(0, -1)]
    [InlineData(-1, -2)]
    public void NormalItem_SellInDecreasesByOne(int startSellIn, int endSellin)
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Normal Item", SellIn = startSellIn, Quality = 0 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();

        Assert.Equal(endSellin, Items[0].SellIn);
    }
}