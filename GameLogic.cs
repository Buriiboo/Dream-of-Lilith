namespace Dream;

public class GameLogic
{
    
    private Player player;
    private Room currentRoom; // Assuming Room is a class in your project

    public GameLogic()
    {
        List<Item> initialInventory = new List<Item> { /* add initial items */ };
        List<Spell> initialSpells = new List<Spell> { /* add initial spells */ };
        player = new Player("", 0, 0, 0, 0.0, 0, 0, initialInventory, initialSpells);
        currentRoom = new Room(); // You need to define the Room class
    }

    public void StartGame()
    {
        player = Player.CharacterCreation();
       
        // Main game loop
        while (true)
        {
            Console.WriteLine($"{player.name} stands in {currentRoom.Description}");
            Console.WriteLine("1. Enter the next room");
            Console.WriteLine("2. Engage in a monster battle");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Handle entering the next room
                    break;
                case "2":
                    // Handle engaging in a monster battle
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}