using life_simulator.Classes;
using life_simulator.Plants;
using life_simulator.Render;
using System;
using System.Drawing;
using System.Numerics;

namespace life_simulator {
	class ScenePlantTest : Scene {
		readonly Random random = new();

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
			
			TickTimer tmr = new(world, (uint ticks) => {
				Vector2 spawnPosition = new(
					(float)Math.Round(this.random.NextDouble() * this.World.Size.X),
					(float)Math.Round(this.random.NextDouble() * this.World.Size.Y)
				);

				if (this.World.IsCellEmpty(spawnPosition))
					(new Plant(world)).SetPos(spawnPosition);
			}, 60, 0);
		}

		public new static ScenePlantTest Create(World world) {
			return new ScenePlantTest(world);
		}
	}
}
