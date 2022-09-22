using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using life_simulator.Classes.abstractCreature;

namespace life_simulator.Classes.Animal
{
    internal class Animal : Creature, IAlive
    {
        public void die()
        {
            throw new NotImplementedException();
        }

        public void eat()
        {
            throw new NotImplementedException();
        }

        public bool isHungry()
        {
            throw new NotImplementedException();
        }

        public void move()
        {
            throw new NotImplementedException();
        }

        public void pair<T>(T partner)
        {
            throw new NotImplementedException();
        }

        public void searchFood<T>(T food)
        {
            throw new NotImplementedException();
        }
    }
    enum AnimalTypes
    {
        Predator,
        Herbivorous
    }
}
