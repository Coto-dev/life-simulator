using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using life_simulator.Render;
using life_simulator.Classes;
using System.Drawing;

namespace life_simulator {
	class SceneRenderTest : Scene {

		private static double ToRadians(double angle) {
			return (Math.PI / 180) * angle;
		}

		public SceneRenderTest(World world) : base(world) {
			EntityRender entR = new();

			Entity test1 = new(world);
			Entity test2 = new(world);
			Entity test3 = new(world);

			entR.SetColor(Color.FromArgb(unchecked((int)0xffffffff)));
			entR.SetSize(test1.Render.GetSize());
			entR.SetSvg("assets/svg/Basketball.svg");
			entR.Rerender();

			test2.Render.SetEntityRender(entR);
			test3.Render.SetEntityRender(entR);

			test1.SetPos(new(4.5f, 5f));
			test2.SetPos(new(1.5f, 1.5f));
			test3.SetPos(new(2f));

			Console.WriteLine((uint)0.5f);

			//test1.setVel(new Vector2(0.1f, 0.1f));

			TickTimer tmr = new(world, (uint ticks) => {
				uint mult = 3;

				ticks *= mult;

				test1.SetVel(new Vector2(
					(float)Math.Sin(ToRadians(ticks % 360)),
					(float)Math.Cos(ToRadians(ticks % 360))) * 0.02f * mult
				);

				//Console.WriteLine(test1.getPos());
			}, 1, 0);
		}

		public new static SceneRenderTest Create(World world) {
			return new SceneRenderTest(world);
		}
	}
}
