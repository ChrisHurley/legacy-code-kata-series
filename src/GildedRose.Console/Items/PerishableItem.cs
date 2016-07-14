namespace GildedRose.Console.Items
{
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
}