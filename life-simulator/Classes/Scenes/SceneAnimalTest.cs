using life_simulator.Classes.Animal;
using life_simulator.Plants;
using life_simulator.Render;
using System;
using System.Numerics;

namespace life_simulator {
	class SceneAnimalTest : Scene {
		readonly Random random = new();

		private void RandomSpawnPredator(World world) {
			(new Predator(world)).SetPos(new Vector2((float)Math.Round(this.random.NextDouble() * this.World.Size.X),
				(float)Math.Round(this.random.NextDouble() * this.World.Size.Y)));
		}

		private void RandomSpawnHerbivorous(World world) {
			(new Herbivorous(world)).SetPos(new Vector2((float)Math.Round(this.random.NextDouble() * this.World.Size.X),
				(float)Math.Round(this.random.NextDouble() * this.World.Size.Y)));
		}

		private void RandomSpawnHuman(World world) {
			(new Human(world)).SetPos(new Vector2((float)Math.Round(this.random.NextDouble() * this.World.Size.X),
				(float)Math.Round(this.random.NextDouble() * this.World.Size.Y)));
		}

		private void RandomSpawnPlant(World world) {
			Vector2 spawnPosition = new(
				(float)Math.Round(this.random.NextDouble() * this.World.Size.X),
				(float)Math.Round(this.random.NextDouble() * this.World.Size.Y)
			);

			if (this.World.IsCellEmpty(spawnPosition))
				(new Plant(world)).SetPos(spawnPosition);
		}

		public SceneAnimalTest(World world) : base(world) {


			Predator predator1 = new(world);
			Predator predator2 = new(world);
			Predator predator3 = new(world);

			Herbivorous herbivorous1 = new(world);
			Herbivorous herbivorous2 = new(world);
			Herbivorous herbivorous3 = new(world);
			Herbivorous herbivorous4 = new(world);
			Herbivorous herbivorous5 = new(world);

			predator1.SetPos(new Vector2(3.5f, 3.5f));
			predator2.SetPos(new Vector2(6.6f, 6.6f));
			predator3.SetPos(new Vector2(7.6f, 8.6f));

			herbivorous1.SetPos(new Vector2(5.7f, 6.5f));
			herbivorous2.SetPos(new Vector2(3.7f, 4.5f));
			herbivorous3.SetPos(new Vector2(2.7f, 4.5f));
			herbivorous4.SetPos(new Vector2(5.7f, 3.5f));
			herbivorous5.SetPos(new Vector2(4.7f, 3.5f));

			TickTimer tmr = new(world, (uint ticks) => {
				this.RandomSpawnPlant(world);
				this.RandomSpawnPlant(world);
				this.RandomSpawnHuman(world);
				this.RandomSpawnHerbivorous(world);
				this.RandomSpawnHerbivorous(world);
				this.RandomSpawnPredator(world);
			}, 60, 0);

		}

		public new static SceneAnimalTest Create(World world) {
			return new SceneAnimalTest(world);
		}
	}
}
