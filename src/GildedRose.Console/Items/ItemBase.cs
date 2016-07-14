using System;

namespace GildedRose.Console.Items
{
    public abstract class ItemBase : IEquatable<ItemBase>
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

        public bool Equals(ItemBase other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && SellIn == other.SellIn && Quality == other.Quality;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ItemBase)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name.GetHashCode();
                hashCode = (hashCode * 397) ^ SellIn;
                hashCode = (hashCode * 397) ^ Quality;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, SellIn: {SellIn}, Quality: {Quality}";
        }
    }
}