using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using life_simulator.Render;
using life_simulator.Classes;

namespace life_simulator {
	class SceneTest : Scene {

		private double ToRadians(double angle) {
			return (Math.PI / 180) * angle;
		}

		public SceneTest(World world) : base(world) {
			Entity test1 = new Entity(world);
			Entity test2 = new Entity(world);
			Entity test3 = new Entity(world);

			test1.setPos(new Vector2(200, 500));
			test2.setPos(new Vector2(100, 100));
			test3.setPos(new Vector2(150, 150));

			//test1.setVel(new Vector2(0.1f, 0.1f));

			TickTimer tmr = new TickTimer(world, (uint ticks) => {
				test1.setVel(new Vector2(
					(float)Math.Sin(ToRadians(ticks % 360)),
					(float)Math.Cos(ToRadians(ticks % 360))) * 2f
				);

				//Console.WriteLine(test1.getPos());
			}, 1, 0);

			
		}

		public new static SceneTest Create(World world) {
			return new SceneTest(world);
		}
	}
}
