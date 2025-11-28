namespace CodeQuality.Samples.Legacy.GildedRose;

public class RegularItem : Item, IItem
{
    public static RegularItem FromItem(Item item) => new()
    {
        Quality = item.Quality,
        Name = item.Name,
        SellIn = item.SellIn,
    };

    public void UpdateQuality()
    {
        if (this.Quality > MinQuality)
        {
            this.DecreaseQuality();
        }

        this.DecreaseSellIn();
        if (this.SellIn < MinSellIn && this.Quality > MinQuality)
        {
            this.DecreaseQuality();
        }
    }
}