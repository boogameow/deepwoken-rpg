using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Gambler : Move
    {
        public Gambler(int minDamage = 6, int maxDamage = 12, int critChance = 100, int missChance = 40) : base("Gambler", minDamage, maxDamage, critChance, missChance)
        {
            
        }

        public override void Attack(Entity user, Entity target, Battle battle)
        {
            int damage = (int)(Entity.random.Next(minDamage, maxDamage) * user.stats.dmgModifier);

            if (RollForCrit() == true)
            {
                damage *= 8;
                Console.WriteLine($"{user.name} HIT IT BIG ON {target.name} WITH A {damage} ({target.stats.defense} DEF) DAMAGE CRIT!");

                Thread.Sleep(1000);
            } else
                Console.WriteLine($"{user.name} gambled and lost on {target.name}, dealing {damage} ({target.stats.defense} DEF) damage.");

            target.Damage(damage);
        }
    }
}
