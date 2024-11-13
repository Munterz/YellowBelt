using System;

class Program
{
    static void Main()
    {
        Player player = new Player
        {
            Name = "Arin",
            Health = 100,
            Level = 1,
            Experience = 0,
            Damage = 20
        };

        Enemy enemy = new Enemy
        {
            Type = "Orc",
            Health = 50
        };
        
        player.Attack(enemy);
        
        player.GainExperience(50);
    }
}

class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Damage { get; set; }
    
    public void Attack(Enemy enemy)
    {
        Console.WriteLine($"Player {Name} attacks the {enemy.Type} and deals {Damage} damage.");
        enemy.TakeDamage(Damage); 
    }
    
    public void GainExperience(int exp)
    {
        Experience += exp;
        Console.WriteLine($"Player {Name} gains {exp} experience points.");
    }
}

class Enemy
{
    public string Type { get; set; }
    public int Health { get; set; }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health > 0)
        {
            Console.WriteLine($"{Type} takes {damage} damage. Remaining Health: {Health}");
        }
        else
        {
            Console.WriteLine($"{Type} takes {damage} damage and is defeated.");
        }
    }
}