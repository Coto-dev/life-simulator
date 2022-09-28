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
		protected int MaxHp;
		protected int Hp;
		protected int Satiety;
		protected int LifeTicks;
		protected object? sex;
		public Animal(World world) : base(world) {
			MaxHp = 200;
			Satiety = 150;
			Hp = 200;
			LifeTicks = 0;
		}
		public void Die() {
			Remove();
        }
        
		public void Chase<T>(Entity chaser) {
			float eps = 0.15f;
			Entity? target = World.FindFirstEnt<T>(chaser);

			if (target == null) {
				Move();
				return;
			}
				
			float x = target.GetPos().X - GetPos().X;
			float y = target.GetPos().Y - GetPos().Y;
			SetVel(new Vector2((float)x / 20, (float)y / 20));

			if (Math.Abs(target.GetPos().X - chaser.GetPos().X) < eps && Math.Abs(target.GetPos().Y - chaser.GetPos().Y) < eps) {
				target.Remove();
				Eat();	
			}
		}
		public bool IsHungry() {
            if (Satiety > 50) return false;
			else return true;
        }
        public void Move() {
			LifeTicks++;
			if (LifeTicks % 10 == 0) {
				Random rnd = new Random();
				switch (rnd.Next(0, 4)) {
					case 0:
						SetVel(new Vector2((float)rnd.NextDouble() * -0.03f, (float)rnd.NextDouble() * -0.03f));
						break;
					case 1:
						SetVel(new Vector2((float)rnd.NextDouble() * -0.03f, (float)rnd.NextDouble() * 0.03f));
						break;
					case 2:
						SetVel(new Vector2((float)rnd.NextDouble() * 0.03f, (float)rnd.NextDouble() * -0.03f));
                        break;
					case 3:
						SetVel(new Vector2((float)rnd.NextDouble() * 0.03f, (float)rnd.NextDouble() * 0.03f));
                        break;
					default:
						SetVel(new Vector2((float)rnd.NextDouble() * 0.03f, (float)rnd.NextDouble() * 0.03f));
						break;
				}		
			}
		}


		public void Pair<T>(T partner) {

		}
		public void Eat() {
			Satiety = 100;
		}

	}
    enum AnimalTypes {
        Predator,
        Herbivorous
    }
}
