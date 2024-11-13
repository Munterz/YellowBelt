using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] enemies = { "Goblin", "Orc", "Troll" };
        Console.WriteLine("Enemies:");
        foreach (string enemy in enemies)
        {
            Console.WriteLine(enemy);
        }
        
        List<string> inventory = new List<string> { "Sword", "Shield", "Potion" };
        Console.WriteLine("\nPlayer Inventory:");
        foreach (string item in inventory)
        {
            Console.WriteLine(item);
        }
        
        inventory.Add("Helmet");
        Console.WriteLine("\nUpdated Inventory:");
        foreach (string item in inventory)
        {
            Console.WriteLine(item);
        }
    }
}