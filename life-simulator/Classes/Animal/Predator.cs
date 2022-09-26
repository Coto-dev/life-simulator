using life_simulator.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace life_simulator.Classes.Animal {
	internal class Predator : Animal {
		public override void Tick() {
			base.Tick();
			if (isHungry()) {
				die();
			}
			Satiety -= 2;
			foreach (Entity ent in World.EntsTick) {

				if (ent is Herbivorous) {
					Console.WriteLine(ent.GetType());
					Console.WriteLine(ent.getPos());
				}
			}
			
		}
		public Predator(World world) : base(world) {
			Color = Color.White;
		
		}
	}
}
