using life_simulator.Render;
using System.Drawing;

namespace life_simulator.Classes.Animal {
	internal class Predator : Animal {
		public Predator(World world) : base(world) {
			this.Render.SetSvg("assets/svg/Predator.svg");
			this.Render.SetColor(Color.Orange);
			this.Render.Rerender();
		}

		public override void Tick() {
			base.Tick();
			this.Live<Herbivorous, Human>();
		}
	}
}
