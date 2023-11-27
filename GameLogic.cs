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
                    battle.StartBattle(new UndeadList().GetRandomUndead());
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
    private Player player;
    private Monster currentEnemy;
    public BattleLogic(Player player)
    {
        this.player = player;
    }

    public void StartBattle(Monster enemy)
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
                    AbilityList();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            // Enemy's turn (You can add more logic here)
            EnemyTurn();
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

    private void BasicAttack()
    {
        int damageDealt = CalculateDamage(player.Damage, currentEnemy.Armor);
        currentEnemy.CurrentHP -= damageDealt;
        Console.WriteLine($"You dealt {damageDealt} damage to {currentEnemy.Name}!");
    }

   private void AbilityList()
    {
        // Display the list of abilities
        Console.WriteLine("Choose an ability:");
        for (int i = 0; i < player.Abilities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {player.Abilities[i].Name}");
        }

        // Take input from the user
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= player.Abilities.Count)
        {
            // User input is valid, use the selected ability
            player.Abilities[choice - 1].UseAbility(player, currentEnemy);
        }
        else
        {
            Console.WriteLine("Invalid choice. Try again.");
        }
    }
    private void spellList()
    {   
        // Display the list of abilities
        Console.WriteLine("Choose an ability:");
        for (int i = 0; i < player.Abilities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {player.Abilities[i].Name}");
            Console.ReadLine();
        }
    }

    private void EnemyTurn()
    {
        // For simplicity, let's assume the enemy always performs a basic attack
        int damageDealt = CalculateDamage(currentEnemy.Damage, player.Armor);
        player.CurrentHP -= damageDealt;
        Console.WriteLine($"{currentEnemy.Name} dealt {damageDealt} damage to you!");
    }

    private int CalculateDamage(int attackerDamage, int defenderArmor)
    {
        // Basic damage calculation (you might want to enhance this based on your game mechanics)
        int damage = Math.Max(1, attackerDamage - defenderArmor);
        return damage;
    }
}
