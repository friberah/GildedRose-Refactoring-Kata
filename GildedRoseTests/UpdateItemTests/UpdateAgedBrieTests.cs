using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests.UpdateAgedBrieTests;

public class UpdateAgedBrieTests
{
    [Fact]
    public void AgedBrie_IncreasesInQualityUpTo50()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(11, Items[0].Quality);
    }

    [Fact]
    public void AgedBrie_QualityDoesNotIncreasePast50()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(50, Items[0].Quality);
    }

   [Fact]
    public void AgedBrie_SellInDecreasesBy1()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 }
        };
        var app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(4, Items[0].SellIn);
    }
}