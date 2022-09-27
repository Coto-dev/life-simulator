using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using life_simulator.Render;

namespace life_simulator.Classes.Animal
{

    abstract class Animal : Entity, IAlive
    {
		protected int Hp;
		protected int Satiety;
		protected object? sex;

		private static double ToRadians(double angle) {
			return (Math.PI / 180) * angle;
		}
		public Animal(World world) : base(world) {
			Satiety = 2000;
			Hp = 100;
		}

		public void Die()
        {
			Remove();
            /*throw new NotImplementedException();*/
        }

        public void Eat()
        {
			Satiety += 2000;
        }
		public void Chase<T>(Entity chaser) {
			float eps = 0.15f;
			Entity? target = World.FindFirstEnt<T>(chaser);
			if (target == null)
				return;
			float x = target.GetPos().X - GetPos().X;
			float y = target.GetPos().Y - GetPos().Y;
			SetVel(new Vector2((float)x /10, (float)y / 10));
			if (Math.Abs(target.GetPos().X - chaser.GetPos().X) < eps && Math.Abs(target.GetPos().Y - chaser.GetPos().Y) < eps) {
				target.Remove();
				Eat();	
			}
		}

		public bool IsHungry()
        {
            if (Satiety >50) return false;
			else return true;
        }

        public void Move()
        {
			SetVel(new Vector2(0.02f, 0.02f));
			/*SetVel(new Vector2(
					(float)Math.Sin(ToRadians(60 % 360)),
					(float)Math.Cos(ToRadians(60 % 360))) * 0.02f * 1
				);*/
			Random rnd =new Random();
			//if (Ticks / 2 == 0)
				SetVel(new Vector2((float)rnd.NextDouble()*0.050f - (float)rnd.NextDouble() * 0.050f, (float)rnd.NextDouble()* 0.050f - (float)rnd.NextDouble() * 0.050f));
		}

        public void Pair<T>(T partner){
        }

        public void SearchFood<T>(T food) {
        }
    }
    enum AnimalTypes
    {
        Predator,
        Herbivorous
    }
}
