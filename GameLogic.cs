namespace Dream
{
    public class GameLogic
    {
        private Player player;
        private Room currentRoom;

        public GameLogic()
        {
            currentRoom = new Room("", "", ""); // Ensure Room class is defined with a matching constructor
        }

        public void StartGame()
        {
            player = Player.CharacterCreation();

            // Main game loop
            while (true)
            {
                Console.WriteLine($"{player.Name} stands in {currentRoom.Description}");
                Console.WriteLine("1. Enter the room");
                Console.WriteLine("2. Battle");
                Console.WriteLine("3. Abilities");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EnterRoom();
                        break;
                    case "2":
                        StartBattle();
                        break;
                    case "3":
                        UseAbilities();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void EnterRoom()
        {
            // Logic for entering the next room
            Console.WriteLine("You enter a new room...");
        }

        private void StartBattle()
        {
            BattleLogic battle = new BattleLogic(player);  // Ensure the constructor matches
            battle.StartBattle(player, new UndeadList().GetRandomUndead());
        }

        private void UseAbilities()
        {
            // Logic for using abilities
            Console.WriteLine("You use an ability...");
        }
    }

    public class BattleLogic
    {
        private Monster currentEnemy;

        public BattleLogic(Player player)
        {
            // Initialize any necessary data
        }

        public void StartBattle(Player player, Monster enemy)
        {
            currentEnemy = enemy;
            Console.WriteLine($"You encounter a {currentEnemy.Name}!");

            while (player.CurrentHP > 0 && currentEnemy.CurrentHP > 0)
            {
                Console.WriteLine($"{player.Name}'s HP: {player.CurrentHP}/{player.MaxHP} | {currentEnemy.Name}'s HP: {currentEnemy.CurrentHP}/{currentEnemy.MaxHP}");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Ability");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BasicAttack(player, currentEnemy);
                        break;
                    case "2":
                        UseAbility(player, currentEnemy);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }

            if (player.CurrentHP <= 0)
            {
                Console.WriteLine("You were defeated!");
            }
            else
            {
                Console.WriteLine($"You defeated the {currentEnemy.Name}!");
            }
        }

        private void BasicAttack(Player player, Monster enemy)
        {
            // Implement basic attack logic
            Console.WriteLine($"{player.Name} attacks {enemy.Name}!");
            // Adjust HP of enemy based on player's attack power
        }

        private void UseAbility(Player player, Monster enemy)
        {
            // Implement ability usage logic
            Console.WriteLine($"{player.Name} uses an ability on {enemy.Name}!");
            // Adjust HP or status of enemy based on ability effects
        }
    }
}
