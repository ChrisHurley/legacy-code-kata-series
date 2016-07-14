using System.Collections;
using System.Collections.Generic;
using GildedRose.Console.Items;

namespace GildedRose.Console
{
    public class Inventory : IEnumerable<ItemBase>
    {
        private IList<ItemBase> Items = new List<ItemBase>();

        public void AddItem(ItemBase item)
        {
            Items.Add(item);
        }

        public void AddAllItems(IList<ItemBase> list)
        {
            foreach (var item in list)
            {
                Items.Add(item);
            }
        }

        public void Update()
        {
            foreach (var item in Items)
            {
                item.Update();
            }
        }

        public IEnumerator<ItemBase> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) Items).GetEnumerator();
        }

    }
}