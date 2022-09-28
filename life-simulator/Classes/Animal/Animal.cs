using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using life_simulator.Render;
using life_simulator.Plants;
using System.Diagnostics;

namespace life_simulator.Classes.Animal {

    abstract class Animal : Entity, IAlive {
		protected int MaxHp;
		protected int Hp;
		protected int Satiety;
		protected object? sex;

		public Animal(World world) : base(world) {
			MaxHp = 200;
			Satiety = 150;
			Hp = 200;
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
			//SetVel(new Vector2((float)x / 20, (float)y / 20));
		Vector2 vec = new Vector2((float)x , (float)y);
		SetVel(new Vector2(vec.X / vec.Length() / 30, vec.Y/ vec.Length() / 30));
			if (Math.Abs(target.GetPos().X - chaser.GetPos().X) < eps && Math.Abs(target.GetPos().Y - chaser.GetPos().Y) < eps) {
				if (target is Plant) {
					if (((Plant)target).isGrown == true) {
						target.Remove();
						Eat();
					} else
						return;	
				} 
				else {
					target.Remove();
					Eat();
				}
				/*target.Remove();
				Eat();*/
			}
		}
		public bool IsHungry() {
            if (Satiety > 50) return false;
			else return true;
        }
        public void Move() {
			if (Ticks % 20 == 0) {
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
