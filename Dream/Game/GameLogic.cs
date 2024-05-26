using System;
using Dream.Models;
using Dream.Logic;

namespace Dream.Game
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
            BattleLogic battle = new BattleLogic();
            battle.StartBattle(player, new UndeadList().GetRandomUndead());
        }

        private void UseAbilities()
        {
            // Logic for using abilities
            Console.WriteLine("You use an ability...");
        }
    }
}
