using life_simulator.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace life_simulator.Classes.Animal {
	internal class Herbivorous : Animal {
		public override void Tick() {
			base.Tick();
			Move();
		}
		public Herbivorous(World world) : base(world) {
			//Color = Color.Green;
			/*Render.SetColor(Color.Green);
			Render.Rerender();*/
		}
	}
}
