// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Models
{
    using System;
    using System.Collections.Generic;
    using Dream.Abilities;

    public class Player : Actor
    {
        public int X { get; private set; } // Player's X position on the map

        public int Y { get; private set; } // Player's Y position on the map

        private char[,] map;  // Reference to game map

        public Player(string name, int maxHP, int currentHP, int maxMana, int currentMana, int level, int damage, int armor, int luck, int exp, List<Item> inventory, List<Ability> abilities, char[,] mapData)
            : base(name, maxHP, currentHP, maxMana, currentMana, level, damage, armor, luck)
        {
            this.Exp = exp;
            this.Inventory = inventory ?? new List<Item>();
            this.Abilities = abilities ?? new List<Ability>();
            this.X = 1;  // Default start position
            this.Y = 1;
            this.map = mapData;
        }

        public List<Item> Inventory { get; set; }

        public List<Ability> Abilities { get; set; }

        public int Exp { get; set; }

        public override void Attack(Actor target)
        {
            Console.WriteLine($"{this.Name} attacks {target.Name}!");
            target.TakeDamage(this.Damage);
        }

        public static Player CharacterCreation(char[,]? mapData = null)
        {
            if (mapData == null)
            {
                mapData = new char[10, 10]; // Default 10x10 empty grid
            }

            Console.WriteLine("What is your name, traveler?");
            string name = Console.ReadLine() ?? "Unknown Hero";
            int maxHP = 500;
            int currentHP = 500;
            int maxMana = 100;
            int currentMana = 100;
            int level = 1;
            int damage = 10;
            int armor = 5;
            int luck = 30;
            int exp = 0;
            List<Item> inventory = new List<Item>();
            List<Ability> abilities = new List<Ability> { new Fireball(), new Frostbolt() };
            Console.WriteLine($"Number of abilities: {abilities.Count}");

            return new Player(name, maxHP, currentHP, maxMana, currentMana, level, damage, armor, luck, exp, inventory, abilities, mapData);
        }

        public void Move(ConsoleKey key)
        {
        int newX = X, newY = Y;

        switch (key)
        {
            case ConsoleKey.W when IsValidMove(X, Y - 1):
                newY--;
                break;
            case ConsoleKey.S when IsValidMove(X, Y + 1):
                newY++;
                break;
            case ConsoleKey.A when IsValidMove(X - 1, Y):
                newX--;
                break;
            case ConsoleKey.D when IsValidMove(X + 1, Y):
                newX++;
                break;
        }

        X = newX;
        Y = newY;
        }

        private bool IsValidMove(int x, int y)
        {
            if (map == null) return false; // Ensure map exists
            if (y < 0 || y >= map.GetLength(0) || x < 0 || x >= map.GetLength(1)) return false; // Prevent out-of-bounds movement
            return map[y, x] != '#'; // Prevent moving into walls
        }
    }
}