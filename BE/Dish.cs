using System;

namespace BE
{
    [path(@"dishes.xml", "Dish", "Name")]
    public class Dish
    {
        public string Name { get; set; }
        public DISH_SIZE Size { get; set; }
        public float Price { get; set; }
        public kosher_level Kusher_level { get; set; }
        public override string ToString()
        {
            return string.Format("Dish\nnumber: {0}, name: {1}, size: {2} price: {3}, kosher level: {4}\n", Name, Size, Price, Kusher_level);
        }

    }
}
