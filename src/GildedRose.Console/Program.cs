using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Items;

namespace GildedRose.Console
{
    internal class Program
    {

        internal static void Main(string[] args)
        {
            UpdateAndPrintItems();

            System.Console.ReadKey();
        }

        internal static void UpdateAndPrintItems()
        {
            System.Console.WriteLine("OMGHAI!");

            Inventory inventory = new Inventory();

            var items = new List<ItemBase>
            {
                new PerishableItem("+5 Dexterity Vest", 10, 20),
                new AgeingItem("Aged Brie", 2, 0),
                new PerishableItem("Elixir of the Mongoose", 5, 7),
                new LegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80),
                new DesirableEventItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new ConjuredItem("Conjured Mana Cake", 3, 6)
            };

            inventory.AddAllItems(items);

            inventory.Update();

            PrintItems(inventory);
        }

        private static void PrintItems(Inventory inventory)
        {
            foreach (var item in inventory)
            {
                System.Console.WriteLine("{0}|{1}|{2}", item.Name, item.Quality, item.SellIn);
            }
        }

    }
}