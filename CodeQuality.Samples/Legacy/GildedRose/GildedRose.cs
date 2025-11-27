namespace CodeQuality.Samples.Legacy.GildedRose;

/// <summary>
/// </summary>
public class GildedRose(IList<Item> items)
{
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            if (this.IsAgedBrie(item))
            {
                this.UpdateAgedBrieQuality(item);
                continue;
            }

            if (this.IsBackstagePass(item))
            {
                this.UpdateQualityForBackstagePass(item);
                continue;
            }

            if (this.IsSulfura(item))
            {
                continue;
            }

            this.UpdateQualityForRegularItem(item);
        }
    }

    private void CheckItemSellInLowerThanElevenToBackStageConcert(Item item)
    {
        if (item.SellIn < 11 && this.IfQualityLowerThanFifty(item))
        {
            this.IncreaseItemQualityWithOne(item);
        }
    }

    private void CheckItemSellInLowerThanSixForBackStageConcert(Item item)
    {
        if (item.SellIn < 6 && this.IfQualityLowerThanFifty(item))
        {
            this.IncreaseItemQualityWithOne(item);
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

    private bool IfQualityLowerThanFifty(Item item)
    {
        return item.Quality < 50;
    }

    private void IncreaseItemQualityWithOne(Item item)
    {
        item.Quality += 1;
    }

    private bool IsAgedBrie(Item item)
    {
        return item.Name == "Aged Brie";
    }

    private bool IsBackstagePass(Item item)
    {
        return item.Name == "Backstage passes to a TAFKAL80ETC concert";
    }

    private bool IsSulfura(Item item)
    {
        return item.Name == "Sulfuras, Hand of Ragnaros";
    }

    private void UpdateAgedBrieQuality(Item item)
    {
        if (this.IfQualityLowerThanFifty(item))
        {
            this.IncreaseItemQualityWithOne(item);
        }

        item.SellIn -= 1;
        if (item.SellIn < 0 && this.IfQualityLowerThanFifty(item))
        {
            this.IncreaseItemQualityWithOne(item);
        }
    }

    private void UpdateQualityForBackstagePass(Item item)
    {
        if (this.IfQualityLowerThanFifty(item))
        {
            this.IncreaseItemQualityWithOne(item);
            this.CheckItemSellInLowerThanElevenToBackStageConcert(item);
            this.CheckItemSellInLowerThanSixForBackStageConcert(item);
        }

        item.SellIn -= 1;
        if (item.SellIn < 0)
        {
            item.Quality -= item.Quality;
        }
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