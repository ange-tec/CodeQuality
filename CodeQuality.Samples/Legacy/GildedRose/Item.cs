namespace CodeQuality.Samples.Legacy.GildedRose;

public class Item
{
    protected const int MaxQuality = 50;
    protected const int MinQuality = 0;
    protected const int MinSellIn = 0;
    private const string AgedBrieName = "Aged Brie";
    private const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
    private const string SulfurasName = "Sulfuras, Hand of Ragnaros";
    public string Name { get; set; }
    public int Quality { get; set; }
    public int SellIn { get; set; }

    public static IItem Parse(Item item)
    {
        if (item.IsAgedBrie())
        {
            return AgedBrie.FromItem(item);
        }

        if (item.IsBackstagePass())
        {
            return BackstagePass.FromItem(item);
        }

        if (item.IsSulfura())
        {
            return Sulfura.FromItem(item);
        }

        return RegularItem.FromItem(item);
    }

    private bool IsAgedBrie() => this.Name == AgedBrieName;

    private bool IsBackstagePass() => this.Name == BackstagePassName;

    private bool IsSulfura() => this.Name == SulfurasName;

    protected void DecreaseSellIn() => this.SellIn--;
    protected void DecreaseQuality() => this.Quality--;
    protected void IncreaseQuality() => this.Quality++;
}