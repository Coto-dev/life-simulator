using life_simulator.Render;
using System.Drawing;

namespace life_simulator.Classes.Animal {
	internal class Human : Animal {
		public Human(World world) : base(world) {
			this.Render.SetSvg("assets/svg/Human.svg");
			this.Render.SetColor(Color.White);
			this.Render.Rerender();
			this.Hp = 300;
		}

		public override void Tick() {
			base.Tick();
			this.Live<Herbivorous, Predator>();
		}
	}
}
