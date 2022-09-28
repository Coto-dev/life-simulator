using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using life_simulator.Render;
using life_simulator.Classes;
using System.Drawing;
using life_simulator.Plants;

namespace life_simulator {
	class ScenePlantTest : Scene {

		Random random = new Random();
		private static double ToRadians(double angle) {
			return (Math.PI / 180) * angle;
		}

		public ScenePlantTest(World world) : base(world) {
			EntityRender entR = new();

			Entity test1 = new(world);
			Entity test2 = new(world);
			Entity test3 = new(world);

			entR.SetColor(Color.White);
			entR.SetSize(test1.Render.GetSize());
			entR.SetSvg("assets/svg/Black_Paw.svg");
			entR.Rerender();


			test2.Render.SetEntityRender(entR);
			test3.Render.SetEntityRender(entR);

			test1.SetPos(new(1f, 1f));
			test2.SetPos(new(2f, 2f));
			test3.SetPos(new(3f, 3f));

			//test1.setVel(new Vector2(0.1f, 0.1f));

			TickTimer tmr = new(world, (uint ticks) => {
				Vector2 spawnPosition = new(
					(float)Math.Round(random.NextDouble() * World.Size.X),
					(float)Math.Round(random.NextDouble() * World.Size.Y)
				);
				if (World.IsCellEmpty(spawnPosition)) {
					(new Plant(world)).SetPos(spawnPosition);
				}
				//Console.WriteLine(test1.getPos());
			}, 60, 0);
		}

		public new static ScenePlantTest Create(World world) {
			return new ScenePlantTest(world);
		}
	}
}
