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
		public Predator(World world) : base(world) {
			Render.SetSvg("assets/svg/Predator.svg");
			Render.SetColor(Color.Orange);
			Render.Rerender();
		}
		public override void Tick() {
			base.Tick();

			Satiety-- ;

			if (Hp == 0) 
				Die();
			
			if (IsHungry()) {
				Hp--;
				Chase<Herbivorous>(this);
			} 
			else {
				if (Hp < MaxHp) 
					Hp++;
				Move();
			}
				
			
		}	
	}
}
