namespace Dream;

public class GameLogic
{
    private Player player;
    private Room currentRoom;

    public GameLogic()
    {
        currentRoom = new Room("", "", ""); // You need to define the Room class
    }

    public void StartGame()
    {
        player = Player.CharacterCreation();

        // Main game loop
        while (true)
        {
            Console.WriteLine($"{player.Name} stands in {currentRoom.Description}");
            Console.WriteLine("1. Enter the room");
            Console.WriteLine("2. Battoru");
            Console.WriteLine("3. Abilities");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Handle entering the next room
                    break;
                case "2":
                    // Handle engaging in a monster battle
                    BattleLogic battle = new BattleLogic(player);  // Pass the player instance to BattleLogic
                    battle.StartBattle(player, new UndeadList().GetRandomUndead());
                    break;
                case "3":
                    // Handle using abilities

                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



public class BattleLogic
{
    public void StartBattle(Player player, Monster enemy)
    {
        currentEnemy = enemy;
        Console.WriteLine($"You encounter a {currentEnemy.Name}!");

        while (player.CurrentHP > 0 && currentEnemy.CurrentHP > 0)
        {
            Console.WriteLine($"{player.Name}'s HP: {player.MaxHP}/{player.CurrentHP} | {currentEnemy.Name}'s HP: {currentEnemy.MaxHP}/{currentEnemy.CurrentHP}");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Ability");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Basic attack logic
                    BasicAttack();
                    break;
                case "2":
                    // Use Ability logic
                    AbilityList(player, currentEnemy);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        // Check who won the battle
        if (player.CurrentHP <= 0)
        {
            Console.WriteLine("You were defeated!");
        }
        else
        {
            Console.WriteLine($"You defeated the {currentEnemy.Name}!");
        }
    }

   
}
