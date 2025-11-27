namespace CodeQuality.Samples.Legacy.GildedRose;

/// <summary>
/// 
/// </summary>
public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (IsItemNameEqualToAgedBrie(i))
            {
                UpdateAgedBrieQuality(i);
                continue;
            }
            
            if (IsItemNameDoesnotEqualToAgedBrie(i) && IsItemDoesnotEqualToBackStagePassesToATafkal80EtcConcert(i))
            {
                if (IfQualityHigherThanZero(i))
                {
                    if (IsItemNameDoesnotEqualToSulfurasHandOfRangnaros(i))
                    {
                        DecreaseItemQualityWithOne(i);
                    }
                }
            }
            else
            {
                if (IfQualityLowerThanFifty(i))
                {
                    IncreaseItemQualityWithOne(i);

                    if (IsItemNameEqualsToBackstagePassesToATafkal80EtcConcert(i))
                    {
                        CheckItemSellInLowerThanElevenToBackStageConcert(i);

                        CheckItemSellInLowerThanSixForBackStageConcert(i);
                    }
                }
            }
            

            if (IsItemNameDoesnotEqualToSulfurasHandOfRangnaros(i))
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            if (Items[i].SellIn < 0)
            {
                if (IsItemNameDoesnotEqualToAgedBrie(i))
                {
                    if (IsItemDoesnotEqualToBackStagePassesToATafkal80EtcConcert(i))
                    {
                        if (IfQualityHigherThanZero(i))
                        {
                            if (IsItemNameDoesnotEqualToSulfurasHandOfRangnaros(i))
                            {
                                DecreaseItemQualityWithOne(i);
                            }
                        }
                    }
                    else
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                }
                else
                {
                    if (IfQualityLowerThanFifty(i))
                    {
                        IncreaseItemQualityWithOne(i);
                    }
                }
            }
        }
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
        return;
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

    private void DecreaseItemQualityWithOne(int i)
    {
        Items[i].Quality = Items[i].Quality - 1;
    }

    private void IncreaseItemQualityWithOne(int i)
    {
        Items[i].Quality = Items[i].Quality + 1;
    }

    private bool IfQualityLowerThanFifty(int i)
    {
        return Items[i].Quality < 50;
    }

    private bool IfQualityHigherThanZero(int i)
    {
        return Items[i].Quality > 0;
    }

    private bool IsItemNameEqualsToBackstagePassesToATafkal80EtcConcert(int i)
    {
        return Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
    }

    private bool IsItemNameDoesnotEqualToSulfurasHandOfRangnaros(int i)
    {
        return Items[i].Name != "Sulfuras, Hand of Ragnaros";
    }

    private bool IsItemDoesnotEqualToBackStagePassesToATafkal80EtcConcert(int i)
    {
        return Items[i].Name != "Backstage passes to a TAFKAL80ETC concert";
    }

    private bool IsItemNameDoesnotEqualToAgedBrie(int i)
    {
        return Items[i].Name != "Aged Brie";
    }
    private bool IsItemNameEqualToAgedBrie(int i)
    {
        return Items[i].Name == "Aged Brie";
    }
}