using life_simulator.Plants;
using life_simulator.Render;
using System;
using System.Numerics;

namespace life_simulator.Classes.Animal {

	abstract class Animal : Entity, IAlive {
		protected int MaxHp;
		protected int Hp;
		protected int MaxSatiety;
		protected int MinSatiety;
		protected int Satiety;
		protected float SpeedCoof;
		protected Animal(World world) : base(world) {
			this.MaxHp = 200;
			this.Hp = 200;
			this.MaxSatiety = 150;
			this.MinSatiety = 50;
			this.Satiety = 150;
			this.SpeedCoof = 30;
		}

		public void Live<T1, T2>() {
			this.Satiety--;

			if (this.Hp == 0)
				this.Die();

			if (!this.IsHungry()) {
				if (this.Hp < this.MaxHp) {
					this.Hp++;
				}

				this.Move();
			} else {
				this.Hp--;
				Chase<T1, T2>();
			}
		}

		public void Die() {
			this.Remove();
		}

		public void Chase<T1, T2>() {
			float eps = 0.15f;
			Entity? target = this.World.FindFirstEnt<T1, T2>(this);

			if (target == null) {
				this.Move();
				return;
			}

			Vector2 direction = target.GetPos() - this.GetPos();

			if(direction.Length() != 0)
				this.SetVel(direction / direction.Length() / this.SpeedCoof);

			if (direction.Length() < eps) {
				if (target is Plant plant) {
					if (plant.isGrown) {
						target.Remove();
						this.Eat();
					}

				} else if (target is Animal animal) {
					animal.Remove();
					this.Eat();
				}
			}
		}

		public bool IsHungry() {
			return this.Satiety <= this.MinSatiety;
		}

		public void Move() {
			if (this.Ticks % 20 == 0) {
				Random rnd = new();

				Vector2 rndV2 = new Vector2((float)rnd.NextDouble(), (float)rnd.NextDouble()) * 2 - new Vector2(1f);

				if (rndV2.Length() == 0)
					return;

				this.SetVel(rndV2 / rndV2.Length() * 0.03f);
			}
		}

		public void Eat() {
			this.Satiety = this.MaxSatiety;
		}
	}
}
