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
		public Render(PictureBox pictureBox) {
			
		}

		internal void drawWorld(PaintEventArgs e, World world) {
			foreach (Entity ent in world.EntsTick) {
				ent.Tick();

				Pen entPen = new Pen(ent.getColor(), 3);
				Vector2 entPos = ent.getPos();
				Vector2 entSizeD2 = ent.getSize() / 2;

				e.Graphics.DrawRectangle(entPen,
						entPos.X - entSizeD2.X,
						entPos.Y - entSizeD2.Y,
						entSizeD2.X,
						entSizeD2.Y);

				entPen.Dispose();
			}

			world.TickTimers();
			world.RemoveOldEnts();
			world.RemoveOldTimer();
		}
	}
}
