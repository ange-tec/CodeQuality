namespace CodeQuality.Samples.Legacy.GildedRose;

/// <summary>
/// </summary>
public class GildedRose
{
    private readonly List<IItem> items;

    /// <summary>
    /// </summary>
    public GildedRose(IList<Item> items) => this.items = items.Select(Item.Parse).ToList();

    public IEnumerable<IItem> ListItems() => new List<IItem>(this.items);

    public void UpdateQuality()
    {
        foreach (var item in this.items)
        {
            item.UpdateQuality();
        }
    }
}