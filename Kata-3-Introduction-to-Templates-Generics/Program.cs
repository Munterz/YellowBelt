using System;
using System.Collections.Generic;

interface IAbility
{
    string Name { get; }
    string Effect { get; }
}

class AttackAbility : IAbility
{
    public string Name { get; private set; }
    public string Effect { get; private set; }

    public AttackAbility(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}

class HealAbility : IAbility
{
    public string Name { get; private set; }
    public string Effect { get; private set; }

    public HealAbility(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}

class AbilityContainer<T> where T : IAbility
{
    private List<T> abilities = new List<T>();

    public void AddAbility(T ability)
    {
        abilities.Add(ability);
        Console.WriteLine($"Added ability: {ability.Name}");
    }

    public void RemoveAbility(T ability)
    {
        abilities.Remove(ability);
        Console.WriteLine($"Removed ability: {ability.Name}");
    }

    public IEnumerable<T> GetAllAbilities()
    {
        return abilities;
    }
}

class Program
{
    static void Main()
    {
        AbilityContainer<IAbility> abilityContainer = new AbilityContainer<IAbility>();
        
        var fireball = new AttackAbility("Fireball", "Deals 50 fire damage.");
        var healingTouch = new HealAbility("Healing Touch", "Restores 30 health.");
        
        abilityContainer.AddAbility(fireball);
        abilityContainer.AddAbility(healingTouch);
        
        Console.WriteLine("\nAll abilities in container:");
        foreach (var ability in abilityContainer.GetAllAbilities())
        {
            Console.WriteLine($"- {ability.Name}: {ability.Effect}");
        }
        
        abilityContainer.RemoveAbility(fireball);
        
        Console.WriteLine("\nUpdated abilities in container:");
        foreach (var ability in abilityContainer.GetAllAbilities())
        {
            Console.WriteLine($"- {ability.Name}: {ability.Effect}");
        }
    }
}
