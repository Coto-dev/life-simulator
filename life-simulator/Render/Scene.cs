using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace life_simulator.Render {
	class Scene {
		public World World;

		public Scene(World world) {
			World = world;
		}

		public static Scene Create(World world) {
			return new Scene(world);
		}
	}
}
