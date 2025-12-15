using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests.UpdateBackstagePassesTests;

public class UpdateBackstagePassesTests
{
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

    [Fact]
    public void Backstage_Sellin_DecreasesBy1()
    {
        IList<Item> items = [new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 }];

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Equal(0, items[0].SellIn);
    }
}