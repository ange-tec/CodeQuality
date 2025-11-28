namespace CodeQuality.Samples.Legacy.GildedRose;

public class BackstagePass : Item, IItem
{
    public void UpdateQuality()
    {
        if (this.Quality < MaxQuality)
        {
            this.IncreaseQuality();
            this.CheckItemSellInLowerThanElevenToBackStageConcert();
            this.CheckItemSellInLowerThanSixForBackStageConcert();
        }

        this.DecreaseSellIn();
        if (this.SellIn < MinSellIn)
        {
            this.Quality = MinQuality;
        }
    }

    private void CheckItemSellInLowerThanElevenToBackStageConcert()
    {
        if (this.SellIn < 11 && this.Quality < MaxQuality)
        {
            this.IncreaseQuality();
        }
    }

    private void CheckItemSellInLowerThanSixForBackStageConcert()
    {
        if (this.SellIn < 6 && this.Quality < MaxQuality)
        {
            this.IncreaseQuality();
        }
    }

    public static BackstagePass FromItem(Item item) => new()
    {
        Quality = item.Quality,
        Name = item.Name,
        SellIn = item.SellIn,
    };
}