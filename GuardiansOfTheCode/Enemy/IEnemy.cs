using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode.Enemy
{
    public interface IEnemy
    {
        int Health { get; set; }
        int Level { get; }
        void Attack(PrimaryPlayer player);
        void Defend(PrimaryPlayer player);
    }
}
