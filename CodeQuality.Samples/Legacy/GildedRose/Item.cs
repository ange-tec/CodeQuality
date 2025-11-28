namespace CodeQuality.Samples.Legacy.GildedRose;

public class Item
{
    protected const int MaxQuality = 50;
    protected const int MinSellIn = 0;
    public string Name { get; set; }
    public int Quality { get; set; }
    public int SellIn { get; set; }

    public bool IsAgedBrie()
    {
        return this.Name == "Aged Brie";
    }

    public bool IsBackstagePass()
    {
        return this.Name == "Backstage passes to a TAFKAL80ETC concert";
    }

    public bool IsSulfura()
    {
        return this.Name == "Sulfuras, Hand of Ragnaros";
    }

    public static IItem Parse(Item item)
    {
        if (item.IsAgedBrie())
        {
            return new AgedBrie
            {
                Quality = item.Quality,
                Name = item.Name,
                SellIn = item.SellIn,
            };
        }

        if (item.IsBackstagePass())
        {
            return new BackstagePass
            {
                Quality = item.Quality,
                Name = item.Name,
                SellIn = item.SellIn,
            };
        }

        if (item.IsSulfura())
        {
            return new Sulfura
            {
                Quality = item.Quality,
                Name = item.Name,
                SellIn = item.SellIn,
            };
        }

        return new RegularItem
        {
            Quality = item.Quality,
            Name = item.Name,
            SellIn = item.SellIn,
        };
    }

    public void UpdateAgedBrieQuality()
    {
        if (this.Quality < MaxQuality)
        {
            this.Quality++;
        }

        this.SellIn -= 1;
        if (this.SellIn < MinSellIn && this.Quality < MaxQuality)
        {
            this.Quality++;
        }
    }

    public void UpdateQualityForBackstagePass()
    {
        if (this.Quality < MaxQuality)
        {
            this.Quality++;
            this.CheckItemSellInLowerThanElevenToBackStageConcert();
            this.CheckItemSellInLowerThanSixForBackStageConcert();
        }

        this.SellIn -= 1;
        if (this.SellIn < MinSellIn)
        {
            this.Quality -= this.Quality;
        }
    }

    private void CheckItemSellInLowerThanElevenToBackStageConcert()
    {
        if (this.SellIn < 11 && this.Quality < MaxQuality)
        {
            this.Quality++;
        }
    }

    private void CheckItemSellInLowerThanSixForBackStageConcert()
    {
        if (this.SellIn < 6 && this.Quality < MaxQuality)
        {
            this.Quality++;
        }
    }
}

public interface IItem
{
    void UpdateQuality();
}

public class AgedBrie : Item, IItem
{
    public void UpdateQuality()
    {
        if (this.Quality < MaxQuality)
        {
            this.Quality++;
        }

        this.SellIn -= 1;
        if (this.SellIn < MinSellIn && this.Quality < MaxQuality)
        {
            this.Quality++;
        }
    }
}

public class BackstagePass : Item, IItem
{
    public void UpdateQuality()
    {
        if (this.Quality < MaxQuality)
        {
            this.Quality++;
            this.CheckItemSellInLowerThanElevenToBackStageConcert();
            this.CheckItemSellInLowerThanSixForBackStageConcert();
        }

        this.SellIn -= 1;
        if (this.SellIn < MinSellIn)
        {
            this.Quality -= this.Quality;
        }
    }

    private void CheckItemSellInLowerThanElevenToBackStageConcert()
    {
        if (this.SellIn < 11 && this.Quality < MaxQuality)
        {
            this.Quality++;
        }
    }

    private void CheckItemSellInLowerThanSixForBackStageConcert()
    {
        if (this.SellIn < 6 && this.Quality < MaxQuality)
        {
            this.Quality++;
        }
    }
}

public class Sulfura : Item, IItem
{
    public void UpdateQuality()
    {
    }
}

public class RegularItem : Item, IItem
{
    public void UpdateQuality()
    {
        if (this.Quality > 0)
        {
            this.Quality--;    
        }
        
        this.SellIn -= 1;
        if (this.SellIn < MinSellIn)
        {
            if (this.Quality > 0)
            {
                this.Quality--;    
            }
        }
    }
}