using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using life_simulator.Render;
using life_simulator.Classes;
using life_simulator.Plants;
using life_simulator.Classes.Animal;
using System.Drawing;

namespace life_simulator {
	class SceneAnimal : Scene {

		Random random = new Random();

		private double ToRadians(double angle) {
			return (Math.PI / 180) * angle;
		}

		private void RandomSpawnPredator(World world) {
			(new Predator(world)).SetPos(new Vector2((float)Math.Round(random.NextDouble() * World.Size.X),
			(float)Math.Round(random.NextDouble() * World.Size.Y)));
		}

		private void RandomSpawnHerbivorous(World world) {
			(new Herbivorous(world)).SetPos(new Vector2((float)Math.Round(random.NextDouble() * World.Size.X),
			(float)Math.Round(random.NextDouble() * World.Size.Y)));
		}

		private void RandomSpawnHuman(World world) {
			(new Human(world)).SetPos(new Vector2((float)Math.Round(random.NextDouble() * World.Size.X),
			(float)Math.Round(random.NextDouble() * World.Size.Y)));
		}

		private void RandomSpawnPlant(World world) {
			Vector2 spawnPosition = new(
					(float)Math.Round(random.NextDouble() * World.Size.X),
					(float)Math.Round(random.NextDouble() * World.Size.Y)
				);
			if (World.IsCellEmpty(spawnPosition)) 
					(new Plant(world)).SetPos(spawnPosition);
		}

		public SceneAnimal(World world) : base(world) {
			

			Predator predator1 = new Predator(world);
			Predator predator2 = new Predator(world);
			Predator predator3 = new Predator(world);

			Herbivorous herbivorous1 = new Herbivorous(world);
			Herbivorous herbivorous2 = new Herbivorous(world);
			Herbivorous herbivorous3 = new Herbivorous(world);
			Herbivorous herbivorous4 = new Herbivorous(world);
			Herbivorous herbivorous5 = new Herbivorous(world);

			predator1.SetPos(new Vector2(3.5f, 3.5f));
			predator2.SetPos(new Vector2(6.6f, 6.6f));
			predator3.SetPos(new Vector2(7.6f, 8.6f));

			herbivorous1.SetPos(new Vector2(5.7f, 6.5f));
			herbivorous2.SetPos(new Vector2(3.7f, 4.5f));
			herbivorous3.SetPos(new Vector2(2.7f, 4.5f));
			herbivorous4.SetPos(new Vector2(5.7f, 3.5f));
			herbivorous5.SetPos(new Vector2(4.7f, 3.5f));

			TickTimer tmr = new(world, (uint ticks) => {
				RandomSpawnPlant(world);
				RandomSpawnPlant(world);
				RandomSpawnHuman(world);
				RandomSpawnHerbivorous(world);
				RandomSpawnHerbivorous(world);
				RandomSpawnPredator(world);
			}, 60, 0);

		}

		public new static SceneAnimal Create(World world) {
			return new SceneAnimal(world);
		}
	}
}
