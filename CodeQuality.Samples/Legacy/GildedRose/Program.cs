using System.Text;

namespace CodeQuality.Samples.Legacy.GildedRose;

public class Program
{
    public static string RunSimulation(int days = 2)
    {
        var sb = new StringBuilder();
        sb.AppendLine("OMGHAI!");

        IList<Item> items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

        var app = new GildedRose(items);
        for (var i = 0; i < days; i++)
        {
            sb.AppendLine("-------- day " + i + " --------");
            sb.AppendLine("name, sellIn, quality");
            foreach (var item in app.ListItems())
            {
                sb.AppendLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }
            sb.AppendLine("");
            app.UpdateQuality();
        }

        return sb.ToString();
    }
}