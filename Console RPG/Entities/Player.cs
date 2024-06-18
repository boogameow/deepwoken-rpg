﻿using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Player : Entity
    {
        public static Player player1 = new Player("Lapis", maxhp: 100,
            new Stats(defense: Entity.random.Next(2, 8), speed: Entity.random.Next(2, 7), deathResist: Entity.random.Next(60, 90), dodgeChance: Entity.random.Next(8, 25)));

        public static Player player2 = new Player("Goku", maxhp: 400,
            new Stats(defense: Entity.random.Next(-30, -15), speed: 10, deathResist: Entity.random.Next(50, 85), dodgeChance: Entity.random.Next(3, 8)));

        public static List<Entity> party = new List<Entity> { player1, player2 };

        public static int coins = 0;
        public static bool hasManorKey = false;

        public Player(string name, int maxhp = default, Stats stats = default) : base(name, maxhp, stats)
        {
        }

        public override string ChooseAction(List<string> choices)
        {
            Console.WriteLine("What would you like to do?");
            return Program.ChooseSomething<string>(choices);
        }

        public override Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("What item would you like to use?");
            return Program.ChooseSomething<Item>(choices);
        }

        public override Move ChooseMove(List<Move> choices)
        {
            Console.WriteLine("What move would you like to use?");
            return Program.ChooseSomething<Move>(choices, true);
        }

        public override Entity ChooseTarget(string moveName, List<Entity> choices)
        {
            // query the player
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Who would you like to use {moveName} on?");
            return Program.ChooseSomething<Entity>(choices);
        }
    }
}
