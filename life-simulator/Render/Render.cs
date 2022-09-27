using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms;
using life_simulator.Classes;

namespace life_simulator.Render {
	public class Render {
		public World World;

		public Render(World world) {
			World = world;
		}

		internal void DrawWorld(PaintEventArgs e) {
			DrawGrid(e);

			foreach (Entity ent in World.EntsTick) {
				ent.Tick();

				Vector2 entPos = (ent.GetPos() - new Vector2(0.5f)) * World.GridSize;
				Vector2 entSize = ent.Render.GetSize() / 2;
				
				e.Graphics.DrawImage(ent.Render.Draw(), entPos.X - entSize.X, entPos.Y - entSize.Y);
			}

			World.TickTimers();
			World.RemoveOldEnts();
			World.RemoveOldTimer();
		}

		internal void DrawGrid(PaintEventArgs e) {
			Pen gridPen = new(Color.FromArgb(unchecked((int)0xff888888)), 1);

			for (int i = 0; i <= (int)World.Size.X; i++)
				e.Graphics.DrawLine(gridPen, i * World.GridSize.X, 0, i * World.GridSize.X, World.Size.Y * World.GridSize.Y);

			for (int i = 0; i <= (int)World.Size.Y; i++)
				e.Graphics.DrawLine(gridPen, 0, i * World.GridSize.Y, World.Size.X * World.GridSize.X, i * World.GridSize.Y);

			gridPen.Dispose();
		}
	}
}
