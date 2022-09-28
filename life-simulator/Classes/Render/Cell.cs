using life_simulator.Classes;
using System.Collections.Generic;
using System.Numerics;

namespace life_simulator.Render {
	public class Cell {
		public Vector2 Coords { get; }
		public HashSet<Entity> Entities { get; }

		public Cell(Vector2 coords) {
			this.Coords = coords;
			this.Entities = new HashSet<Entity>();
		}
	}
}
