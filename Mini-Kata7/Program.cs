using System;

class Program
{
    static void Main()
    {
        Player player = new Player
        {
            Name = "Arin",
            Health = 100,
            Level = 1
        };
        
        Enemy enemy = new Enemy
        {
            Type = "Goblin",
            Health = 50,
            Damage = 10
        };
        
        Console.WriteLine("Player Info:");
        Console.WriteLine($"Name: {player.Name}");
        Console.WriteLine($"Health: {player.Health}");
        Console.WriteLine($"Level: {player.Level}");
        
        Console.WriteLine("\nEnemy Info:");
        Console.WriteLine($"Type: {enemy.Type}");
        Console.WriteLine($"Health: {enemy.Health}");
        Console.WriteLine($"Damage: {enemy.Damage}");
    }
}

class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
}

class Enemy
{
    public string Type { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
}