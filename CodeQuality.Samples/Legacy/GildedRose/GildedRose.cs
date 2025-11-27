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
            if (IsItemNameAgedBrie(i) && IsItemBackStagePassesToATafkal80EtcConcert(i))
            {
                if (Items[i].Quality > 0)
                {
                    if (IsItemNameSulfurasHandOfRangnaros(i))
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            if (Items[i].SellIn < 0)
            {
                if (IsItemNameAgedBrie(i))
                {
                    if (IsItemBackStagePassesToATafkal80EtcConcert(i))
                    {
                        if (Items[i].Quality > 0)
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

    private bool IsItemNameSulfurasHandOfRangnaros(int i)
    {
        return Items[i].Name != "Sulfuras, Hand of Ragnaros";
    }

    private bool IsItemBackStagePassesToATafkal80EtcConcert(int i)
    {
        return Items[i].Name != "Backstage passes to a TAFKAL80ETC concert";
    }

    private bool IsItemNameAgedBrie(int i)
    {
        return Items[i].Name != "Aged Brie";
    }
}