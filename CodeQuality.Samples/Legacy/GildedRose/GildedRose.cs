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
            if (IsItemNameDoesnotEqualToAgedBrie(i) && IsItemDoesnotEqualToBackStagePassesToATafkal80EtcConcert(i))
            {
                if (IfQualityHigherThanZero(i))
                {
                    if (IsItemNameSulfurasHandOfRangnaros(i))
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (IfQualityLowerThanFifty(i))
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (IsItemNameEqualsToBackstagePassesToATafkal80EtcConcert(i))
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (IfQualityLowerThanFifty(i))
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (IfQualityLowerThanFifty(i))
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (IsItemNameSulfurasHandOfRangnaros(i))
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
                            if (IsItemNameSulfurasHandOfRangnaros(i))
                            {
                                Items[i].Quality = Items[i].Quality - 1;
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
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }
            }
        }
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

    private bool IsItemNameSulfurasHandOfRangnaros(int i)
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
}