using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ItemUpdaterTests
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
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 6 };

            UpdateItem(item);

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void BackstagePassItemShouldIncreaseQualityThreeTimesAsFastWhenSellInLessThanSixDays()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 6 };

            UpdateItem(item);

            Assert.AreEqual(9, item.Quality);
            Assert.AreEqual(4, item.SellIn);
        }

        [Test]
        public void BackstagePassItemShouldHaveZeroQualityWhenSellInBelowZero()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 6 };

            UpdateItem(item);

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
        public void ConjuredManaCakeQualityDecreasesTwiceAsFast()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 6, Quality = 10 };

            UpdateItem(item);

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(5, item.SellIn);
        }

        private void UpdateItem(Item item)
        {
            Program.UpdateQuality(new[] { item });
        }
    }


    public abstract class ItemBase
    {
        protected ItemBase(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public string Name { get; }
        public int SellIn { get; protected set; }
        public int Quality { get; protected set; }
        public abstract void Update();

        protected void IncreaseQuality()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
        }

        protected void DecreaseQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }

        protected void DecreaseSellIn()
        {
            SellIn = SellIn - 1;
        }

        protected bool HasPassedSellByDate()
        {
            return SellIn < 0;
        }
    }

    public class AgeingItem : ItemBase
    {
        public AgeingItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void Update()
        {
            IncreaseQuality();
            DecreaseSellIn();

            if (HasPassedSellByDate())
            {
                IncreaseQuality();
            }
        }
    }

    public class PerishableItem : ItemBase
    {
        public PerishableItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void Update()
        {
            DecreaseQuality();
            DecreaseSellIn();

            if (HasPassedSellByDate())
            {
                DecreaseQuality();
            }
        }
    }

    public class LegendaryItem : ItemBase
    {
        public LegendaryItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void Update()
        {
        }
    }
}