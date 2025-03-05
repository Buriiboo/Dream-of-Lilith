// <copyright file="UndeadList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Logic
{
    using System;
    using System.Collections.Generic;
    using Dream.Models;

    public class UndeadList
    {
        private List<Monster> undeads;

        public UndeadList()
        {
            this.undeads = new List<Monster>
            {
                new Monster("Zombie", 50, 50, 0, 0, 1, 5, 2, 1),
                new Monster("Skeleton", 60, 60, 0, 0, 1, 6, 3, 2),
                new Monster("Vampire", 80, 80, 20, 20, 2, 8, 4, 3),
            };
        }

        public Monster GetRandomUndead()
        {
            Random random = new Random();
            int index = random.Next(this.undeads.Count);
            return this.undeads[index];
        }
    }
}
