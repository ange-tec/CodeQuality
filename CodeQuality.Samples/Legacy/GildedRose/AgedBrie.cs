namespace CodeQuality.Samples.Legacy.GildedRose;

public class AgedBrie : Item, IItem
{
    public void UpdateQuality()
    {
        if (this.Quality < MaxQuality)
        {
            this.IncreaseQuality();
        }

        this.DecreaseSellIn();
        if (this.SellIn < MinSellIn && this.Quality < MaxQuality)
        {
            this.IncreaseQuality();
        }
    }

    public static AgedBrie FromItem(Item item) => new()
    {
        Quality = item.Quality,
        Name = item.Name,
        SellIn = item.SellIn,
    };
}