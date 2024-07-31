using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Item> items = new List<Item>
        {
            new Item { Value = 60, Weight = 10 },
            new Item { Value = 100, Weight = 20 },
            new Item { Value = 120, Weight = 30 }
        };

        int capacity = 50;

        int maxValue = GreedyKnapsackByValue(capacity, items);
        Console.WriteLine("Maximum value in Knapsack = " + maxValue);
    }

    public class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }
    }

    public static int GreedyKnapsackByValue(int capacity, List<Item> items)
    {
        // Sắp xếp các item theo giá trị giảm dần
        items = items.OrderByDescending(i => i.Value).ToList();

        int totalWeight = 0;
        int totalValue = 0;

        foreach (var item in items)
        {
            // Nếu thêm item vào ba lô mà không vượt quá sức chứa
            if (totalWeight + item.Weight <= capacity)
            {
                totalWeight += item.Weight;
                totalValue += item.Value;
            }
            // Nếu thêm item vào ba lô mà vượt quá sức chứa
            else
            {
                break;
            }
        }

        return totalValue;
    }
}