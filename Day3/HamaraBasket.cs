using System.Collections.Generic;
using System.Xml.Linq;

namespace hamaraBasket
{
    public class HamaraBasket
    {
        IList<Item> Items;
        
        public HamaraBasket(IList<Item> list) 
        {
            this.Items = list;
        }

        public static HamaraBasket CreateHamaraBasket(IList<Item> list) 
        {
            return new HamaraBasket(list);
        }

        public static IList<Item> CreateHamaraBasketList(string name, int sellIn, int quality)
        {
            Item item = new Item();
            item.Name = name;
            item.Quality = quality;
            item.SellIn = sellIn;
            IList<Item> myList = new List<Item>();
            myList.Add(item);
            return myList;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];

                if (item.Name != "Indian Wine" && item.Name != "Movie Tickets" && item.Name != "Forest Honey")
                {
                    // Decrease quality by 1 for normal items, unless SellIn < 0, in which case quality decreases by 2.
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }
                }
                else if (item.Name == "Indian Wine")
                {
                    // Increase quality for Indian Wine, but max 50.
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
                else if (item.Name == "Movie Tickets")
                {
                    // Movie tickets: increase quality based on SellIn value.
                    if (item.Quality < 50)
                    {
                        if (item.SellIn > 10)
                        {
                            item.Quality++;
                        }
                        else if (item.SellIn <= 10 && item.SellIn > 5)
                        {
                            item.Quality += 2;
                        }
                        else if (item.SellIn <= 5 && item.SellIn > 0)
                        {
                            item.Quality += 3;
                        }
                        else
                        {
                            item.Quality = 0; // Quality becomes 0 when SellIn is 0 or less.
                        }
                    }
                }
                else if (item.Name == "Forest Honey")
                {
                    // Forest Honey quality never changes.
                    item.Quality = item.Quality;
                }

                // Decrease SellIn for all items (except Forest Honey).
                if (item.Name != "Forest Honey")
                {
                    item.SellIn--;
                }

                // After SellIn < 0, items should decrease in quality by 2 instead of 1.
                if (item.SellIn < 0)
                {
                    if (item.Name != "Indian Wine" && item.Name != "Movie Tickets")
                    {
                        if (item.Quality > 0)
                        {
                            item.Quality--;
                        }
                    }
                    else if (item.Name == "Indian Wine")
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                }

                // Ensure that Quality is within the bounds of 0 and 50.
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
                if (item.Quality > 50)
                {
                    item.Quality = 50;
                }
            }
        }


    }
}
