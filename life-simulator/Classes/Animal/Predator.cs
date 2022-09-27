using life_simulator.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace life_simulator.Classes.Animal {
	internal class Predator : Animal {
		public override void Tick() {
			base.Tick();
			
			if (IsHungry()) {
				Chase<Herbivorous>(this);

			} else
				Move();
			Satiety -= 10;

			//Console.WriteLine(World.FindFirstEnt<Herbivorous>(this).GetPos());

			//Chase<Herbivorous>(this);
		}
		public Predator(World world) : base(world) {
			Render.SetSvg("assets/svg/Black_Paw.svg");
			Render.Rerender();
			//World.EntsTick.Add(new Predator());
		}
	}
}
