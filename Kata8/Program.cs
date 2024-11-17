using System;

class Program
{
    static void Main()
    {
        Player player = new Player("Arin", 100, 1);
        
        Console.WriteLine($"Player: {player.Name}, Health: {player.Health}, Level: {player.Level}, Experience: {player.Experience}");
        
        player.GainExperience(50);
        player.GainExperience(60);
        
        Console.WriteLine($"Player: {player.Name}, Health: {player.Health}, Level: {player.Level}, Experience: {player.Experience}");
    }
}

class Player
{
    private int health;
    private int level;
    private int experience;

    public string Name { get; set; }

    public int Health
    {
        get { return health; }
        private set { health = value > 0 ? value : 0; }
    }

    public int Level
    {
        get { return level; }
        set
        {
            if (value >= 0)
                level = value;
            else
                Console.WriteLine("Level cannot be negative.");
        }
    }

    public int Experience
    {
        get { return experience; }
        set
        {
            if (value >= 0)
                experience = value;
            else
                Console.WriteLine("Experience cannot be negative.");
        }
    }
    
    private void LevelUp()
    {
        level++;
        experience = 0;
        Console.WriteLine($"Congratulations! You leveled up to Level {level}.");
    }
    
    public void GainExperience(int exp)
    {
        Experience += exp;
        Console.WriteLine($"Player gains {exp} experience points.");
        if (Experience >= 100)
        {
            LevelUp();
        }
    }
    
    public Player(string name, int initialHealth, int initialLevel)
    {
        Name = name;
        Health = initialHealth;
        Level = initialLevel;
        Experience = 0;
    }
}
