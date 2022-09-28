using life_simulator.Render;
using life_simulator.Plants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace life_simulator.Classes.Animal {
	internal class Herbivorous : Animal {
		public Herbivorous(World world) : base(world) {
			Render.SetSvg("assets/svg/Herbivorous.svg");
			Render.SetColor(Color.Green);
			Render.Rerender();
		}
		public override void Tick() {
			base.Tick();

			Satiety-- ;

			if (Hp == 0) 
				Die();
			
			if (IsHungry()) {
				Hp--;
				Chase<Plant>(this);
			} 
			else {
				if (Hp < MaxHp) 
					Hp++;
				Move();
			}
		}
		
	}
}
