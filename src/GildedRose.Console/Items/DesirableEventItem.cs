namespace GildedRose.Console.Items
{
    public class DesirableEventItem : ItemBase
    {
        public DesirableEventItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void Update()
        {
            // Tickets are more valuable when an event is closer
            if (SellIn <= 10)
            {
                IncreaseQuality();
            }

            // They increase in value much more the closer we are to the event
            if (SellIn <= 5)
            {
                IncreaseQuality();
            }

            IncreaseQuality();
            DecreaseSellIn();

            if (HasPassedSellByDate())
            {
                Quality = 0;
            }
        }
    }
}