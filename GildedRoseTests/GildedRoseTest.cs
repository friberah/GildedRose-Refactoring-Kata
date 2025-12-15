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
    
    // At the end of each day our system lowers both values for every item
    [Fact]
    public void NormalItem_QualityAndSellInDecreaseByOne()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Normal Item", SellIn = 5, Quality = 10 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(4, Items[0].SellIn);
        Assert.Equal(9, Items[0].Quality);
    }
    
    // Once the sell by date has passed, Quality degrades twice as fast
    [Fact]
    public void NormalItem_AfterSellIn_QualityDecreasesByTwo()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Normal Item", SellIn = 0, Quality = 10 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(8, Items[0].Quality);
    }
    
    // The Quality of an item is never negative
    [Fact]
    public void NormalItem_QualityNeverNegative()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Normal Item", SellIn = 5, Quality = 0 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
      
        Assert.Equal(0, Items[0].Quality);
    }
    
    // "Aged Brie" actually increases in Quality the older it gets
    [Fact]
    public void AgedBrie_IncreasesInQuality()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(4, Items[0].SellIn);
        Assert.Equal(11, Items[0].Quality);
    }


    // The Quality of an item is never more than 50
    [Fact]
    public void AllItem_QualityNeverMoreThan50()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(4, Items[0].SellIn);
        Assert.Equal(50, Items[0].Quality);
    }

    [Fact]
    public void Backstage_IncreasesQualityByOne_WhenInitialSellinValueOver10()
    {
        IList<Item> items =
        [
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 }
        ];

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(11, items[0].Quality);
    }

    [Fact]
    public void Backstage_IncreasesQualityByTwo_WhenInitialSellinValueIs10()
    {
        IList<Item> items = [new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 }];

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(12, items[0].Quality);
    }

    [Fact]
    public void Backstage_IncreasesQualityByTwo_WhenInitialSellinValueLessThan10()
    {
        IList<Item> items = [new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 10 }];

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(12, items[0].Quality);
    }

    [Fact]
    public void Backstage_IncreasesQualityByThree_WhenInitialSellinValueIs5()
    {
        IList<Item> items = [new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 }];

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(13, items[0].Quality);
    }

    [Fact]
    public void Backstage_IncreasesQualityByThree_WhenInitialSellinValueLessThan5()
    {
        IList<Item> items = [new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 10 }];

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(13, items[0].Quality);
    }

    [Fact]
    public void Backstage_QualityIsZero_OnTheDayOfConcert()
    {
        IList<Item> items = [new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }];

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void Backstage_QualityIsZero_AfterConcertPassed()
    {
        IList<Item> items = [new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 10 }];

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(0, items[0].Quality);
    }
}