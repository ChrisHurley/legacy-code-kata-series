using System.Collections.Generic;
using GildedRose.Console;
using GildedRose.Console.Items;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ItemUpdateTests
    {
        [Test]
        public void PerishableItemShouldLowerQualityAndSellInByOne()
        {
            var item = new PerishableItem("+5 Dexterity Vest", 3, 6);

            item.Update();

            Assert.AreEqual(5, item.Quality);
            Assert.AreEqual(2, item.SellIn);
        }

        [Test]
        public void PerishableItemShouldLowerQualityTwiceAsFastWhenSellInIsNegative()
        {
            var item = new PerishableItem("+5 Dexterity Vest", -2, 6);

            item.Update();

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(-3, item.SellIn);
        }

        [Test]
        public void PerishableItemShouldLowerQualityTwiceAsFastWhenSellInIsZero()
        {
            var item = new PerishableItem("+5 Dexterity Vest", 0, 6);
        
            item.Update();

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void BackstagePassItemShouldIncreaseQualityTwiceAsFastWhenSellInLessThanElevenDays()
        {
            var item = new DesirableEventItem("Backstage passes to a TAFKAL80ETC concert", 10, 6);

            item.Update();

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void DesirableEventItemShouldIncreaseQualityThreeTimesAsFastWhenSellInLessThanSixDays()
        {
            var item = new DesirableEventItem("Backstage passes to a TAFKAL80ETC concert", 5, 6);

            item.Update();

            Assert.AreEqual(9, item.Quality);
            Assert.AreEqual(4, item.SellIn);
        }

        [Test]
        public void DesirableEventItemShouldHaveZeroQualityWhenSellInBelowZero()
        {
            var item = new DesirableEventItem("Backstage passes to a TAFKAL80ETC concert", 0, 6);

            item.Update();

            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void AgeingItemQualityIncreasesTwiceAsFastWhenSellInIsLessThanZero()
        {
            var item = new AgeingItem("Aged Brie", 0, 6);

            item.Update();

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void PerishableItemQualityIsNeverNegative()
        {
            var item = new PerishableItem("+5 Dexterity Vest", 10, 0);

            item.Update();

            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void LegendarytItemNeverDecreasesInQualityAndNeverHasToBeSold()
        {
            var item = new LegendaryItem("Sulfuras, Hand of Ragnaros", 10, 80);
            item.Update();

            Assert.AreEqual(80, item.Quality);
            Assert.AreEqual(10, item.SellIn);
        }

        [Test]
        public void AgeingItemQualityCanNeverBeMoreThanFifty()
        {
            var item = new AgeingItem("Aged Brie", -1, 50);

            item.Update();

            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(-2, item.SellIn);
        }

        [Test]
        public void ConjuredItemQualityDecreasesTwiceAsFast()
        {
            var item = new ConjuredItem("Conjured Mana Cake", 6, 10);

            item.Update();

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(5, item.SellIn);
        }

    }
}