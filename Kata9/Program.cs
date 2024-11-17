using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Player player = new Player { Name = "Arin", Health = 100, Level = 1 };
        
        Enemy enemy = new Enemy { Type = "Goblin", Health = 50, Damage = 10 };
        
        NPC npc = new NPC { Name = "NPC", Dialogue = "Welcome to our village!" };
        
        Merchant merchant = new Merchant
        {
            Name = "Merchant",
            Inventory = new List<string> { "Sword", "Shield", "Potion" }
        };
        
        player.Attack(enemy, 20);
        npc.Speak();
        merchant.Trade();
    }
}

class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }

    public void Attack(Enemy enemy, int damage)
    {
        Console.WriteLine($"{Name} attacks {enemy.Type} and deals {damage} damage.");
        enemy.TakeDamage(damage);
    }
}

class Enemy
{
    public string Type { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Type} takes {damage} damage. Remaining health: {Health}");
    }
}

class NPC
{
    public string Name { get; set; }
    public string Dialogue { get; set; }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: {Dialogue}");
    }
}

class Merchant
{
    public string Name { get; set; }
    public List<string> Inventory { get; set; }

    public void Trade()
    {
        Console.WriteLine($"{Name}'s inventory: {string.Join(", ", Inventory)}");
    }
}