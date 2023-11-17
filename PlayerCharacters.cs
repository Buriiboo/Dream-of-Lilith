namespace Dream;

public class Player : Character
{
    // Constructor for creating a Player object
    public Player(string name, int maxHP, int currentHP, double damage, int armor, int luck) : base(name, maxHP, currentHP, damage, armor, luck)
    {
    }

    // Static method for character creation (assuming it's part of the Player class)
    public static Player CharacterCreation()
    {   System.Console.WriteLine("What is your name, traveler?");
        string name = Console.ReadLine() ?? ""; // You need to implement logic to get the player's name
        int maxHP = 100;  // Example maxHP
        int currentHP = 100;  // Example currentHP
        double damage = 10.0;  // Example damage
        int armor = 5;  // Example armor
        int luck = 3;  // Example luck

        return new Player(name, maxHP, currentHP, damage, armor, luck);
    }
}

