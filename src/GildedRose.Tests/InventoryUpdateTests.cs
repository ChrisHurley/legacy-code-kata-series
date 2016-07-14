using System.IO;
using GildedRose.Console;
using GildedRose.Console.Items;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class InventoryUpdateTests
    {

        [Test]
        public void InventoryIsUpdated()
        {
            var inventory = new Inventory();

            inventory.AddAllItems(new ItemBase[]
            {
                new PerishableItem("+5 Dexterity Vest", 10, 20),
                new AgeingItem("Aged Brie", 2, 0),
                new PerishableItem("Elixir of the Mongoose", 5, 7),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80),
                new DesirableEventItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new ConjuredItem("Conjured Mana Cake", 3, 6)
            });

            inventory.Update();

            CollectionAssert.AreEquivalent(new ItemBase[]
            {
                new PerishableItem("+5 Dexterity Vest", 9, 19),
                new AgeingItem("Aged Brie", 1, 1),
                new PerishableItem("Elixir of the Mongoose", 4, 6),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80),
                new DesirableEventItem("Backstage passes to a TAFKAL80ETC concert", 14, 21),
                new ConjuredItem("Conjured Mana Cake", 2, 4)
            }, inventory);
        }
    }
}