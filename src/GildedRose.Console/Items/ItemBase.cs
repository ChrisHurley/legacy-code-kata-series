namespace GildedRose.Console.Items
{
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
}