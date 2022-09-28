using life_simulator.Plants;
using life_simulator.Render;
using System.Drawing;

namespace life_simulator.Classes.Animal {
	internal class Herbivorous : Animal {
		public Herbivorous(World world) : base(world) {
			this.Render.SetSvg("assets/svg/Herbivorous.svg");
			this.Render.SetColor(Color.Green);
			this.Render.Rerender();
			this.SpeedCoof = 20;
		}

		public override void Tick() {
			base.Tick();
			this.Live<Plant, Plant>();
		}
	}
}
