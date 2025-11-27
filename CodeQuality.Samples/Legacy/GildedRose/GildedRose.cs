namespace CodeQuality.Samples.Legacy.GildedRose;

/// <summary>
/// </summary>
public class GildedRose(IList<Item> items)
{
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            if (item.IsAgedBrie())
            {
                item.UpdateAgedBrieQuality();
                continue;
            }

            if (item.IsBackstagePass())
            {
                item.UpdateQualityForBackstagePass();
                continue;
            }

            if (item.IsSulfura())
            {
                continue;
            }

            this.UpdateQualityForRegularItem(item);
        }
    }

    private void DecreaseItemQualityWithOne(Item item)
    {
        item.Quality -= 1;
    }

    private bool IfQualityHigherThanZero(Item item)
    {
        return item.Quality > 0;
    }

    private void UpdateQualityForRegularItem(Item item)
    {
        if (this.IfQualityHigherThanZero(item))
        {
            this.DecreaseItemQualityWithOne(item);
        }

        item.SellIn -= 1;
        if (item.SellIn < 0 && this.IfQualityHigherThanZero(item))
        {
            this.DecreaseItemQualityWithOne(item);
        }
    }
}