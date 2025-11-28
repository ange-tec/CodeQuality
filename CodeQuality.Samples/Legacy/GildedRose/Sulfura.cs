namespace CodeQuality.Samples.Legacy.GildedRose;

public class Sulfura : Item, IItem
{
    public static Sulfura FromItem(Item item) => new()
    {
        Quality = item.Quality,
        Name = item.Name,
        SellIn = item.SellIn,
    };

    public void UpdateQuality()
    {
    }
}