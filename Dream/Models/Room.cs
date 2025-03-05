// <copyright file="Room.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Models
{
    public class Room
    {
        public Room(string name, string description, string enemyDescription)
        {
            this.Name = name;
            this.Description = description;
            this.EnemyDescription = enemyDescription;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string EnemyDescription { get; set; }
    }
}
