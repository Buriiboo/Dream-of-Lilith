namespace Dream;

public class GameLogic
{
    private Player player;
    private Room currentRoom;

    public GameLogic()
    {
        List<Item> initialInventory = new List<Item> { /* add initial items */ };
        List<Ability> initialAbilities = new List<Ability> { /* add initial skills */ };
        player = new Player("Player", 100, 100, 100, 100, 1, 10, 5, 3, 0, initialInventory, initialAbilities);
        currentRoom = new Room("", "", ""); // You need to define the Room class
    }

    public void StartGame()
    {
        player = Player.CharacterCreation();

        // Main game loop
        while (true)
        {
            Console.WriteLine($"{player.Name} stands in {currentRoom.Description}");
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

public class BattleLogic
{
    private Monster currentEnemy;

    public void SetCurrentEnemy(Monster monster)
    {
        currentEnemy = monster;
        Console.WriteLine($"You are now fighting a {currentEnemy.Name}!");
    }

    public void AttackCurrentEnemy()
    {
        if (currentEnemy != null)
        {
            // Perform attack logic on the current enemy
            Console.WriteLine($"Attacking {currentEnemy.Name}!");
            // Other attack logic...
        }
        else
        {
            Console.WriteLine("No current enemy to attack.");
        }
    }
}
