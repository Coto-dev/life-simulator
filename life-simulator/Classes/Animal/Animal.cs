using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using life_simulator.Classes.abstractCreature;
using life_simulator.Render;

namespace life_simulator.Classes.Animal
{
    abstract class Animal : Creature, IAlive
    {
	
		public Animal(World world) : base(world) {
			Satiety = 2000;
			Hp = 100;
		}

		public void die()
        {
			Remove();
            /*throw new NotImplementedException();*/
        }

        public void eat()
        {
            throw new NotImplementedException();
        }

        public bool isHungry()
        {
            if (Satiety >50) return false;
			else return true;
        }

        public void move()
        {
			setVel(new Vector2(1, 1));
        }

        public void pair<T>(T partner){
        }

        public void searchFood<T>(T food) {
        }
    }
    enum AnimalTypes
    {
        Predator,
        Herbivorous
    }
}
