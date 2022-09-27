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

		private static double ToRadians(double angle) {
			return (Math.PI / 180) * angle;
		}

		public ScenePlantTest(World world) : base(world) {
			EntityRender entR = new();

			Entity test1 = new(world);
			Entity test2 = new(world);
			Entity test3 = new(world);
			Plant test4 = new(world);
			Plant test5 = new(world);
			Plant test6 = new(world);
			Plant test7 = new(world);

			entR.SetColor(Color.White);
			entR.SetSize(test1.Render.GetSize());
			entR.SetSvg("assets/svg/Black_Paw.svg");
			entR.Rerender();


			test2.Render.SetEntityRender(entR);
			test3.Render.SetEntityRender(entR);

			test1.SetPos(new(1f, 1f));
			test2.SetPos(new(2f, 2f));
			test3.SetPos(new(3f, 3f));
			test4.SetPos(new(4f, 4f));
			test5.SetPos(new(6f, 6f));
			test6.SetPos(new(7f, 7f));
			test7.SetPos(new(8f, 8f));

			//test1.setVel(new Vector2(0.1f, 0.1f));

			TickTimer tmr = new(world, (uint ticks) => {

				//Console.WriteLine(test1.getPos());
			}, 1, 0);
		}

		public new static ScenePlantTest Create(World world) {
			return new ScenePlantTest(world);
		}
	}
}
