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
    
    // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    [Fact]
    public void UpdateQuality_SulfurasNeverDecreasesQuality()
    {
        var items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = 10;
    }
    
    // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    [Fact]
    public void UpdateQuality_SulfurasNeverDecreasesSellIn()
    {
        var items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].SellIn = 10;
    }
    
    // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
    // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
    // Quality drops to 0 after the concert
    [Theory]
    [InlineData(12, 10, 11)]
    [InlineData(11, 10, 11)]
    [InlineData(10, 10, 12)]
    [InlineData(9, 10, 12)]
    [InlineData(8, 10, 12)]
    [InlineData(7, 10, 12)]
    [InlineData(6, 10, 12)]
    [InlineData(5, 10, 13)]
    [InlineData(4, 10, 13)]
    [InlineData(3, 10, 13)]
    [InlineData(2, 10, 13)]
    [InlineData(1, 10, 13)]
    [InlineData(0, 10, 13)]
    [InlineData(-1, 10, 0)]
    public void UpdateQuality_BackstagePassesUpdatesQualityBasedOnSellIn(int sellIn, int quality, int expectedQuality)
    {
        var items = new List<Item> { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = expectedQuality;
    }
    
    // "Conjured" items degrade in Quality twice as fast as normal items
    [Fact(Skip = "Pending to add this logic after refactoring")]
    public void UpdateQuality_ConjuredDecreasesQualityBy2()
    {
        var items = new List<Item> { new() { Name = "Conjured", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = 8;
    }
    
    // "Conjured" items degrade in Quality twice as fast as normal items
    [Fact(Skip = "Pending to add this logic after refactoring")]
    public void UpdateQuality_ConjuredDecreasesSellInBy1()
    {
        var items = new List<Item> { new() { Name = "Conjured", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].SellIn = 9;
    }
    
    // Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
    [Fact(Skip = "Pending to add this logic after refactoring")]
    public void UpdateQuality_SulfurasHasAFixedQualityOf80()
    {
        var items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Quality = 80;
    }
}