namespace Dream;

public class Player : Character
{
    public List<Item> Inventory { get; set; }
    public List<Spell> Spells { get; set; }

    public Player(string name, int maxHP, int currentHP, int level, double damage, int armor, int luck, List<Item> inventory, List<Spell> spells)
        : base(name, maxHP, currentHP, level, damage, armor, luck)
    {
        Inventory = inventory ?? new List<Item>();
        Spells = spells ?? new List<Spell>();
    }

    // Static method for character creation
    public static Player CharacterCreation()
    {
        Console.WriteLine("What is your name, traveler?");
        string name = Console.ReadLine() ?? ""; // You need to implement logic to get the player's name
        int maxHP = 100;  // start maxHP
        int currentHP = 100;  // start currentHP
        int level = 1;  // start level
        double damage = 10.0;  // start damage
        int armor = 5;  // start armor
        int luck = 3;  // start luck

        return new Player(name, maxHP, currentHP, level, damage, armor, luck, new List<Item>(), new List<Spell>());
        
    }
}

