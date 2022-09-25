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

		public SceneTest(World world) : base(world) {
			Entity test1 = new Entity(world);
			Entity test2 = new Entity(world);
			Entity test3 = new Entity(world);

			test1.setPos(new Vector2(0, 0));
			test2.setPos(new Vector2(100, 100));
			test3.setPos(new Vector2(150, 150));

			
		}

		public new static SceneTest Create(World world) {
			return new SceneTest(world);
		}
	}
}
