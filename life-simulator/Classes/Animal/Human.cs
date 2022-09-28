using life_simulator.Render;
using life_simulator.Plants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace life_simulator.Classes.Animal {
	internal class Human : Animal {
		public Human(World world) : base(world) {
			Render.SetSvg("assets/svg/Human.svg");
			Render.SetColor(Color.White);
			Render.Rerender();
			Hp = 300;
		}

		public override void Tick() {
			base.Tick();
			Live<Herbivorous, Predator>();
		}
	}
}
