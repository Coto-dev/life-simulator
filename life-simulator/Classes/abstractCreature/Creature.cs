using life_simulator.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace life_simulator.Classes.abstractCreature
{
    internal abstract class Creature : Entity
    {
        protected int Hp;
		protected int Satiety;
        protected  object? sex;

		protected Creature(World world) : base(world) {
		}
	}
}
