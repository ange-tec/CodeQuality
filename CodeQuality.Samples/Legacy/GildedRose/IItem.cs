namespace CodeQuality.Samples.Legacy.GildedRose;

public interface IItem
{
    public string Name { get; }
    public int Quality { get; }
    public int SellIn { get; }
    void UpdateQuality();
}