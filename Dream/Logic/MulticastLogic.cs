// <copyright file="MulticastLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dream.Logic
{
    using Dream.Models;

    public class MulticastLogic //pending for name change. This class is responsible for calculating multicast level and probabilities. "multicast" is a temporary name.
    {
        public int RollMulticastLevel(Player player)
        {
            int[] probabilities = this.CalculateProbabilities(player);
            int roll = new Random().Next(1, 101);

            if (roll <= probabilities[0])
            {
                return 0;
            }
            else if (roll <= probabilities[0] + probabilities[1])
            {
                return 2;
            }
            else if (roll <= probabilities[0] + probabilities[1] + probabilities[2])
            {
                return 3;
            }
            else if (roll <= probabilities[0] + probabilities[1] + probabilities[2] + probabilities[3])
            {
                return 4;
            }
            else
            {
                return -1;
            }
        }

        public int[] CalculateProbabilities(Player player)
        {
            int baseProbability = 25;
            int luckModifier = player.Luck / 10;

            int[] probabilities = new int[4];
            probabilities[0] = baseProbability;
            probabilities[1] = baseProbability + luckModifier;
            probabilities[2] = baseProbability - luckModifier;
            probabilities[3] = luckModifier;

            for (int i = 0; i < probabilities.Length; i++)
            {
                probabilities[i] = Math.Max(1, Math.Min(100, probabilities[i]));
            }

            return probabilities;
        }
    }
}
