using Bees.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Bees.Pages
{
    public class IndexBase : ComponentBase
    {
        protected List<Bee> BeeList = new List<Bee>();
        protected int Damage = 0;

        protected void CreateBee()
        {
            BeeList = new List<Bee>();
            for (int i = 1; i <= 10; i++)
            {
                BeeList.AddRange(new List<Bee>{
                    new Bee
                    {
                        Name = $"{BeeType.Queen} {i}",
                        Health = 100,
                        BeeType = BeeType.Queen
                    },
                    new Bee
                    {
                        Name = $"{BeeType.Worker} {i}",
                        Health = 100,
                        BeeType = BeeType.Worker
                    },
                    new Bee
                    {
                        Name = $"{BeeType.Drone} {i}",
                        Health = 100,
                        BeeType = BeeType.Drone
                    }
                });                
            }          
        }

        protected void HurtBeeRandom(Bee bee)
        {
            if (bee.Dead) return;

            var random = new Random();
            int damage = random.Next(0, 81);
            var damageToDeal = (bee.Health / 100) * damage;

            DamageBee(bee, damageToDeal);
        }

        public void DamageBee(Bee bee, float damage)
        {
            Damage = 0;

            if (bee.Dead || damage > 100) return;

            var damageToDeal = (bee.Health / 100) * damage;                        
            bee.Health = bee.Health -= damageToDeal;

            bee.Dead = CheckLife(bee);
        }

        private bool CheckLife(Bee bee)
        {
            switch (bee.BeeType)
            {
                case BeeType.Worker:
                    return bee.Health <= 70.00;
                case BeeType.Queen:
                    return bee.Health <= 20.00;
                case BeeType.Drone:
                    return bee.Health <= 50.00;
                default:
                    break;
            }

            return true;
        }
    }
}
