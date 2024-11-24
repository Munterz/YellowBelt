using System;

class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Action PrimaryAction { get; set; }
}

class Program
{
    static void Main()
    {
        Character warrior = new Character
        {
            Name = "Warrior",
            Health = 40,
            PrimaryAction = () => Console.WriteLine("Warrior attacks!")
        };

        Character healer = new Character
        {
            Name = "Healer",
            Health = 70,
            PrimaryAction = () => Console.WriteLine("Healer heals the character with the lowest health!")
        };
        
        Console.WriteLine($"{warrior.Name} starts with {warrior.Health} health.");
        Console.WriteLine($"{healer.Name} starts with {healer.Health} health.");
        
        if (warrior.Health < 50)
        {
            Console.WriteLine("Warrior has low health and attacks first:");
            warrior.PrimaryAction.Invoke();
        }

        if (healer.Health > warrior.Health)
        {
            Console.WriteLine("Healer sees Warrior needs healing:");
            healer.PrimaryAction.Invoke();
        }
    }
}