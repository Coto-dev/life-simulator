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
		protected int MaxSatiety;
		protected int MinSatiety;
		protected int Satiety;
		protected int SpeedCoof;
		protected object? sex;

		protected Animal(World world) : base(world) {
			MaxHp = 200;
			Hp = 200;
			MaxSatiety = 150;
			MinSatiety = 50;
			Satiety = 150;
			SpeedCoof = 30;
		}

		public void Live<T1, T2>() {
			Satiety-- ;

			if (Hp == 0) 
				Die();
			
			if (IsHungry()) {
				Hp--;
				Chase<T1, T2>(this);
			} 
			else {
				if (Hp < MaxHp) 
					Hp++;
				Move();
			}
		}

		public void Die() {
			Remove();
        }
        
		public void Chase<T1, T2>() {
			float eps = 0.15f;
			Entity? target = World.FindFirstEnt<T1, T2>(this);

			if (target == null) {
				Move();
				return;
			}
				
			float x = target.GetPos().X - GetPos().X;
			float y = target.GetPos().Y - GetPos().Y;

		Vector2 vec = new Vector2((float)x , (float)y);
		SetVel(new Vector2(vec.X / vec.Length() / SpeedCoof, vec.Y/ vec.Length() / SpeedCoof));
			if (Math.Abs(target.GetPos().X - chaser.GetPos().X) < eps && Math.Abs(target.GetPos().Y - chaser.GetPos().Y) < eps) {
				if (target is Plant) {
					if (((Plant)target).isGrown == true) {
						target.Remove();
						Eat();
					} 
					else
						return;	
				} 
				else {
					target.Remove();
					Eat();
				}
			}
		}

		public bool IsHungry() {
            if (Satiety > MinSatiety) return false;
			else return true;
        }

        public void Move() {
			if (Ticks % 20 == 0) {
				Random rnd = new Random();
				float x = (float)rnd.NextDouble() * 0.03f;
				float y = (float)rnd.NextDouble() * 0.03f;
				switch (rnd.Next(0, 4)) {
					case 0:
						SetVel(new Vector2(x * -1, y * -1));
						break;
					case 1:
						SetVel(new Vector2(x * -1, y));
						break;
					case 2:
						SetVel(new Vector2(x, y * -1));
                        break;
					case 3:
						SetVel(new Vector2(x, y));
                        break;
					default:
						SetVel(new Vector2(x, y));
						break;
				}		
			}
		}

		public void Eat() {
			Satiety = MaxSatiety;
		}

		public void Pair<T>(T partner) {

		}
		
	}
}
