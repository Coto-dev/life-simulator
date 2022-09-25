using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using life_simulator.Classes;

namespace life_simulator.Render {
	public class Cell {
		public Vector2 Coords { get; }
		public HashSet<Entity> Entities { get; }

		public Cell(Vector2 coords) {
			Coords = coords;
			Entities = new HashSet<Entity>();
		}
	}
}
