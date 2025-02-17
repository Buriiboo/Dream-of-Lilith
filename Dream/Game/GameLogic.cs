// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Game
{
    using System;
    using Dream.Abilities;
    using Dream.Logic;
    using Dream.Models;

    public class GameLogic
    {
        private Room currentRoom;

        public Player Player { get; set; }

        public GameLogic()
        {
            this.currentRoom = new Room(string.Empty, string.Empty, string.Empty); // Ensure Room class is defined with a matching constructor
            this.Player = new Player(string.Empty, 0, 0, 0, 0, 0, 0, 0, 0, 0, new List<Item>(), new List<Ability>(), new char[10, 10]); // Ensure Player class is defined with a matching constructor
        }

        public void StartGame()
        {
            this.Player = Player.CharacterCreation();

            // Main game loop
            while (true)
            {
                Console.WriteLine($"{this.Player.Name} stands in {this.currentRoom.Description}");
                Console.WriteLine("1. Enter the room");
                Console.WriteLine("2. Battle");
                Console.WriteLine("3. Abilities");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        this.EnterRoom();
                        break;
                    case "2":
                        this.StartBattle();
                        break;
                    case "3":
                        this.UseAbilities();
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
            BattleLogic battle = new () { CurrentEnemy = new UndeadList().GetRandomUndead() };
            battle.StartBattle(this.Player, battle.CurrentEnemy);
        }

        private void UseAbilities()
        {
            // Logic for using abilities
            Console.WriteLine("You use an ability...");
        }
    }
}
