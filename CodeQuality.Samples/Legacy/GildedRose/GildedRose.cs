namespace CodeQuality.Samples.Legacy.GildedRose;

/// <summary>
/// </summary>
public class GildedRose(IList<Item> items)
{
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            var parsedItem = Item.Parse(item);
            parsedItem.UpdateQuality();
        }
    }
}