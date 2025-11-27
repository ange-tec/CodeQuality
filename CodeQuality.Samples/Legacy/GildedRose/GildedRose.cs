namespace CodeQuality.Samples.Legacy.GildedRose;

/// <summary>
/// </summary>
public class GildedRose
{
    private readonly IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (this.IsAgedBrie(i))
            {
                UpdateAgedBrieQuality(i);
                continue;
            }

            if (this.IsBackstagePass(i))
            {
                this.UpdateQualityForBackstagePass(i);
                continue;
            }

            if (this.IsSulfura(i))
            {
                continue;
            }

            this.UpdateQualityForRegularItem(i);
        }
    }

    private void CheckItemSellInLowerThanElevenToBackStageConcert(int i)
    {
        if (Items[i].SellIn < 11)
        {
            if (IfQualityLowerThanFifty(i))
            {
                IncreaseItemQualityWithOne(i);
            }
        }
    }

    private void CheckItemSellInLowerThanSixForBackStageConcert(int i)
    {
        if (Items[i].SellIn < 6)
        {
            if (IfQualityLowerThanFifty(i))
            {
                IncreaseItemQualityWithOne(i);
            }
        }
    }

    private void DecreaseItemQualityWithOne(int i)
    {
        Items[i].Quality = Items[i].Quality - 1;
    }

    private bool IfQualityHigherThanZero(int i)
    {
        return Items[i].Quality > 0;
    }

    private bool IfQualityLowerThanFifty(int i)
    {
        return Items[i].Quality < 50;
    }

    private void IncreaseItemQualityWithOne(int i)
    {
        Items[i].Quality = Items[i].Quality + 1;
    }

    private bool IsAgedBrie(int i)
    {
        return Items[i].Name == "Aged Brie";
    }

    private bool IsBackstagePass(int i)
    {
        return Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
    }

    private bool IsSulfura(int i)
    {
        return Items[i].Name == "Sulfuras, Hand of Ragnaros";
    }

    private void UpdateAgedBrieQuality(int i)
    {
        if (IfQualityLowerThanFifty(i))
        {
            IncreaseItemQualityWithOne(i);
        }

        Items[i].SellIn = Items[i].SellIn - 1;
        if (Items[i].SellIn < 0)
        {
            if (IfQualityLowerThanFifty(i))
            {
                IncreaseItemQualityWithOne(i);
            }
        }
    }

    private void UpdateQualityForBackstagePass(int i)
    {
        if (this.IfQualityLowerThanFifty(i))
        {
            this.IncreaseItemQualityWithOne(i);
            this.CheckItemSellInLowerThanElevenToBackStageConcert(i);
            this.CheckItemSellInLowerThanSixForBackStageConcert(i);
        }

        this.Items[i].SellIn = this.Items[i].SellIn - 1;
        if (this.Items[i].SellIn < 0)
        {
            this.Items[i].Quality = this.Items[i].Quality - this.Items[i].Quality;
        }
    }

    private void UpdateQualityForRegularItem(int i)
    {
        if (this.IfQualityHigherThanZero(i))
        {
            this.DecreaseItemQualityWithOne(i);
        }

        this.Items[i].SellIn = this.Items[i].SellIn - 1;
        if (this.Items[i].SellIn < 0)
        {
            if (this.IfQualityHigherThanZero(i))
            {
                this.DecreaseItemQualityWithOne(i);
            }
        }
    }
}