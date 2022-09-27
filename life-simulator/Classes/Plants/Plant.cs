using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using life_simulator.Classes;
using life_simulator.Render;
using System.Drawing;

namespace life_simulator.Plants
{
    public class Plant : Entity
    {
        public bool isEdible;
        public bool isGrown;

		public Plant(World world) : base(world) {
			isFreezed = true;
			Render.SetColor(Color.Yellow);
			Render.SetSvg("assets/svg/Plant.svg");
			Render.Rerender();
		}

		override public void Tick() {
			base.Tick();
			if (Ticks == 100) {
				grow();
				Console.WriteLine(Ticks);
			}
		}

		private void grow()
        {
			isEdible = true;
			isGrown = true;
			Render.SetColor(Color.Green);
			Render.Rerender();
		}
	}
}
