
interface ICharacter
{
    void Speak();
}

interface ICombat
{
    void Attack(Character target);
    void TakeDamage(int damage);
}

interface ITrade
{
    void Trade(Player player);
}

abstract class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public bool IsAlive => Health > 0;

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }
}

class Player : Character, ICombat
{
    public int Level { get; private set; } = 1;
    public int Experience { get; private set; } = 0;

    public Player(string name, int health) : base(name, health) { }

    public void Attack(Character target)
    {
        int damage = 20;
        Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage.");
        if (target is ICombat combatTarget)
            combatTarget.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage. Health left: {Health}");
    }

    public void Heal()
    {
        Health += 10;
        Console.WriteLine($"{Name} heals for 10 health. Current health: {Health}");
    }

    public void GainExperience(int amount)
    {
        Experience += amount;
        Console.WriteLine($"{Name} gains {amount} experience points.");
    }
}

class Enemy : Character, ICombat
{
    public int Damage { get; private set; }

    public Enemy(string name, int health, int damage) : base(name, health)
    {
        Damage = damage;
    }

    public void Attack(Character target)
    {
        Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage.");
        if (target is ICombat combatTarget)
            combatTarget.TakeDamage(Damage);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
        if (!IsAlive)
            Console.WriteLine($"{Name} is defeated!");
    }
}

class NPC : Character, ICharacter
{
    public NPC(string name) : base(name, 0) { }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Welcome to our village!");
    }
}

class Merchant : Character, ICharacter, ITrade
{
    public List<string> Inventory { get; private set; } = new List<string> { "Sword", "Shield", "Potion" };

    public Merchant(string name) : base(name, 0) { }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: Take a look at my wares.");
    }

    public void Trade(Player player)
    {
        Console.WriteLine("Available items: " + string.Join(", ", Inventory));
    }
}

class Game
{
    private Player _player;

    public void Start()
    {
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine();
        _player = new Player(playerName, 50);
        Console.WriteLine($"{_player.Name} says: Ready for battle!");

        GameLoop();
    }

    private void GameLoop()
    {
        Random random = new Random();
        while (_player.IsAlive)
        {
            int encounter = random.Next(1, 4);

            if (encounter == 1)
            {
                Enemy enemy = new Enemy("Goblin", 30, 5);
                Console.WriteLine($"\nA wild {enemy.Name} appears with {enemy.Health} health and {enemy.Damage} damage!");

                while (enemy.IsAlive && _player.IsAlive)
                {
                    Console.WriteLine("\nChoose an action:\n1. Attack\n2. Heal");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        _player.Attack(enemy);
                        if (enemy.IsAlive)
                            enemy.Attack(_player);
                    }
                    else if (choice == "2")
                    {
                        _player.Heal();
                        enemy.Attack(_player);
                    }
                }

                if (_player.IsAlive)
                    _player.GainExperience(30);
            }
            else if (encounter == 2)
            {
                NPC npc = new NPC("Villager");
                Console.WriteLine("\nYou encounter a Villager.");
                npc.Speak();
            }
            else if (encounter == 3)
            {
                Merchant merchant = new Merchant("Merchant");
                Console.WriteLine("\nYou meet a Merchant.");
                merchant.Speak();
                merchant.Trade(_player);
            }
        }

        Console.WriteLine("Game Over. You have died.");
    }
}

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();
    }
}
