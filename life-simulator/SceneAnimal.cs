using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using life_simulator.Render;
using life_simulator.Classes;
using life_simulator.Classes.Animal;

namespace life_simulator {
	class SceneAnimal : Scene {

		private double ToRadians(double angle) {
			return (Math.PI / 180) * angle;
		}

		public SceneAnimal(World world) : base(world) {
			Entity test1 = new Entity(world);
			Entity test2 = new Entity(world);
			Entity test3 = new Entity(world);
			Predator test4 = new Predator(world);
			Herbivorous test5 = new Herbivorous(world);
			Herbivorous test6 = new Herbivorous(world);

			test1.setPos(new Vector2(200, 500));
			test2.setPos(new Vector2(100, 100));
			test3.setPos(new Vector2(150, 150));
			test4.setPos(new Vector2(150, 150));
			test6.setPos(new Vector2(170, 150));
			test4.move();
			test5.move();
			test6.move();
			//test1.setVel(new Vector2(0.1f, 0.1f));

			TickTimer tmr = new TickTimer(world, (uint ticks) => {
				test1.setVel(new Vector2(
					(float)Math.Sin(ToRadians(ticks % 360)),
					(float)Math.Cos(ToRadians(ticks % 360))) * 2f
				);

				//Console.WriteLine(test1.getPos());
			}, 1, 0);
		

		}

		public new static SceneAnimal Create(World world) {
			return new SceneAnimal(world);
		}
	}
}
