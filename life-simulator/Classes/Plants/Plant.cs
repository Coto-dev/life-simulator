using life_simulator.Classes;
using life_simulator.Render;
using System;
using System.Drawing;

namespace life_simulator.Plants {
	public class Plant : Entity {
		public bool isEdible;
		public bool isGrown;
		public int random;
		readonly Random rnd = new();

		public Plant(World world) : base(world) {
			this.isFreezed = true;
			this.Render.SetColor(Color.Yellow);
			this.Render.SetSvg("assets/svg/Plant.svg");
			this.Render.Rerender();
			this.random = this.rnd.Next(1, 150);
		}

		override public void Tick() {
			base.Tick();

			if (this.Ticks == this.random)
				this.Grow();
		}

		private void Grow() {
			this.isEdible = true;
			this.isGrown = true;
			this.Render.SetColor(Color.Green);
			this.Render.Rerender();
		}
	}
}
