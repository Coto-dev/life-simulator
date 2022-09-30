using life_simulator.Classes;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace life_simulator.Render {
	public class Render {
		private World World;

		public Render(World world) {
			this.World = world;
		}

		internal void DrawWorld(PaintEventArgs e) {
			this.DrawGrid(e);

			foreach (Entity ent in this.World.EntsTick) {
				ent.Tick();

				Vector2 entPos = (ent.GetPos() - new Vector2(0.5f)) * this.World.GridSize;
				Vector2 entSize = ent.Render.GetSize() / 2;

				e.Graphics.DrawImage(ent.Render.Draw(), entPos.X - entSize.X, entPos.Y - entSize.Y);
			}

			this.World.TickTimers();
			this.World.RemoveOldEnts();
			this.World.RemoveOldTimer();
		}

		internal void DrawGrid(PaintEventArgs e) {
			Pen gridPen = new(Color.FromArgb(unchecked((int)0xff888888)), 1);

			for (int i = 0; i <= (int)this.World.Size.X; i++) {
				e.Graphics.DrawLine(gridPen, i * this.World.GridSize.X, 0, i * this.World.GridSize.X, this.World.Size.Y * this.World.GridSize.Y);
			}

			for (int i = 0; i <= (int)this.World.Size.Y; i++) {
				e.Graphics.DrawLine(gridPen, 0, i * this.World.GridSize.Y, this.World.Size.X * this.World.GridSize.X, i * this.World.GridSize.Y);
			}

			gridPen.Dispose();
		}
	}
}
