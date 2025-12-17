using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    // At the end of each day our system lowers both values for every item
    [Fact]
    public void UpdateQuality_LowersSellInForEveryItem()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].SellIn = 9;
    }
    
    // At the end of each day our system lowers both values for every item
    [Fact]
    public void UpdateQuality_LowersQualityForEveryItem()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = 9;
    }
    
    //Once the sell by date has passed, Quality degrades twice as fast
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void UpdateQuality_ReducedQualityByTwoWhenSellInIsLessOrEqualToZero(int sellIn)
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = sellIn, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = 8;
    }
    
    // The Quality of an item is never negative
    [Fact]
    public void UpdateQuality_NeverSetsNegativeQuality()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = 0;
    }
    
    // "Aged Brie" actually increases in Quality the older it gets
    [Fact]
    public void UpdateQuality_AgedBrie_IncreasesQualityByOne()
    {
        var items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = 11;
    }
    
    // The Quality of an item is never more than 50
    [Fact]
    public void UpdateQuality_ItemWithQualityEqualTo50_NeverIncreasesTheQuality()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 10, Quality = 50 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = 50;
    }
}