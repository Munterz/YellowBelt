using System;

class Character
{
    public string Name { get; set; }
    public int Health { get; private set; }
    
    public delegate void CharacterAction(Character target);
    
    public event Action HealthChanged;
    
    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }
    
    public void Attack(Character target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}!");
        target.ReduceHealth(10);
    }
    
    private void ReduceHealth(int damage)
    {
        Health -= damage;
        HealthChanged?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        Character warrior = new Character("Warrior", 100);
        Character healer = new Character("Healer", 80);
        
        warrior.HealthChanged += () => Console.WriteLine($"{warrior.Name} now has {warrior.Health} health.");
        healer.HealthChanged += () => Console.WriteLine($"{healer.Name} now has {healer.Health} health.");
        
        warrior.Attack(healer);
        healer.Attack(warrior);
    }
}