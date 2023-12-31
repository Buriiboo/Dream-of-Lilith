namespace Dream;

public class Player : Actor
{
    Monster currentEnemy;
    int Exp { get; set; }
    public List<Item> Inventory { get; set; }
    public List<Ability> Abilities { get; set; }
    
    public Player(string name, int maxHP, int currentHP, int maxMana, int currentMana, int level, int damage, int armor, int luck, int exp, List<Item> inventory, List<Ability> abilities)
        : base(name, maxHP, currentHP, maxMana, currentMana, level, damage, armor, luck)
    {   
        Exp = exp;
        Inventory = inventory ?? new List<Item>();
        Abilities = new List<Ability>();    
    }

    // Static method for character creation
    public static Player CharacterCreation()
    {
        Console.WriteLine("What is your name, traveler?");
        string name = Console.ReadLine() ?? ""; // You need to implement logic to get the player's name
        int maxHP = 500;  // start maxHP
        int currentHP = 500;  // start currentHP
        int maxMana = 100;  // start maxMana
        int currentMana = 100;  // start currentMana
        int level = 1;  // start level
        int damage = 10;  // start damage
        int armor = 5;  // start armor
        int luck = 30;  // start luck
        int exp = 0;  // start exp
        List<Item> inventory = new List<Item>();  // start inventory
        List<Ability> abilities = new List<Ability> { new Fireball(), new Frostbolt() }; // start spells;
        Console.WriteLine($"Number of abilities: {abilities.Count}");


        Player player = new Player(name, maxHP, currentHP, maxMana, currentMana, level, damage, armor, luck, exp, inventory, abilities);
        return player;
    }
}

