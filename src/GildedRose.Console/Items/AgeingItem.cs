namespace GildedRose.Console.Items
{
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
}