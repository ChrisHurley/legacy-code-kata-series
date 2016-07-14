namespace GildedRose.Console.Items
{
    public class ConjuredItem : ItemBase
    {
        public ConjuredItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void Update()
        {
            DecreaseQuality();
            DecreaseQuality();
            DecreaseSellIn();
        }
    }
}