using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using life_simulator.Classes;

namespace life_simulator.Render {
	public class World {
		public Cell[,] Cells { get; }
		public Vector2 Size;
		public Vector2 GridSize;

		public World(Vector2 size, Vector2 gridSize) {
			GridSize = gridSize;
			Size = size;

			Cells = new Cell[((uint)size.X), ((uint)size.Y)];

			for (uint x = 0; x < ((uint)size.X); x++) {
				for (uint y = 0; y < ((uint)size.Y); y++) {
					Cells[x, y] = new Cell(new Vector2(x, y));
				}
			}
		}

		public void setEntityCellPos(Entity ent, Vector2 ?LastPos, Vector2 NewPos) {
			if (LastPos != null) {
				Vector2 LastPosToGrid = LastPos.Value / this.GridSize;
				Cells[((uint)(LastPosToGrid.X)), ((uint)LastPosToGrid.Y)].Entities.Remove(ent);
			}

			Vector2 NewPosToGrid = NewPos / this.GridSize;
			Cells[((uint)NewPosToGrid.X), ((uint)NewPosToGrid.Y)].Entities.Add(ent);
		}
	}
}
