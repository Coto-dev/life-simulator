using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using life_simulator.Render;
using life_simulator.Classes;
using life_simulator.Classes.Animal;
using System.Drawing;

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
			Predator test10= new Predator(world);
			Predator test11 = new Predator(world);
			Herbivorous test5 = new Herbivorous(world);
			Herbivorous test6 = new Herbivorous(world);
			Herbivorous test7 = new Herbivorous(world);
			Herbivorous test8 = new Herbivorous(world);
			Herbivorous test9 = new Herbivorous(world);
			test5.Render.SetColor(Color.Blue);
			test6.Render.SetColor(Color.Yellow);
			test5.Render.Rerender();
			test6.Render.Rerender();
			/*test1.setPos(new Vector2(200, 500));
			test2.setPos(new Vector2(100, 100));
			test3.setPos(new Vector2(150, 150));*/
			test4.SetPos(new Vector2(3.5f, 3.5f));
			test6.SetPos(new Vector2(1.7f, 1.5f));
			test7.SetPos(new Vector2(3.7f, 1.5f));
			test8.SetPos(new Vector2(1.7f, 4.5f));
			test9.SetPos(new Vector2(5.7f, 1.5f));
			test10.SetPos(new Vector2(6.6f, 6.6f));
			test11.SetPos(new Vector2(7.6f, 8.6f));
			//test4.Move();
			test5.Move();
			test6.Move();
			test7.Move();
			test8.Move();
			test9.Move();
			/*test10.Move();
			test11.Move();*/
			//test1.setVel(new Vector2(0.1f, 0.1f));

			TickTimer tmr = new TickTimer(world, (uint ticks) => {
				test6.SetVel(new Vector2(
					(float)Math.Sin(ToRadians(ticks % 360)),
					(float)Math.Cos(ToRadians(ticks % 360))) * 0.02f
				);

				//Console.WriteLine(test1.getPos());
			}, 1, 0);
		

		}

		public new static SceneAnimal Create(World world) {
			return new SceneAnimal(world);
		}
	}
}
