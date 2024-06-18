﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Slash : Move
    {
        public Slash(int minDamage = 8, int maxDamage = 29, int critChance = 12, int missChance = 0) : base("Slash", minDamage, maxDamage, critChance, missChance)
        {
            
        }

        public override void Attack(Entity user, Entity target, Battle battle)
        {
            int damage = (int)(Entity.random.Next(minDamage, maxDamage) * user.stats.dmgModifier);

            if (RollForCrit() == true)
            {
                damage *= 2;
                Console.WriteLine($"{user.name} used {name} on {target.name} for a {damage} ({target.stats.defense} DEF) damage CRIT!");

                Thread.Sleep(1000);
            } else
                Console.WriteLine($"{user.name} used {name} on {target.name} for {damage} ({target.stats.defense} DEF) damage!");

            target.Damage(damage);
        }
    }
}
