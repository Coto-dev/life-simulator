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
		public Vector2 Size { get; }
		public Vector2 GridSize { get; }
		public List<Entity> EntsTick { get; }
		public List<Entity> EntsRemove { get; }
		public List<TickTimer> TimersTick { get; }
		public List<TickTimer> TimersRemove { get; }

		public World(Vector2 size, Vector2 gridSize) {
			EntsRemove = new List<Entity>();
			EntsTick = new List<Entity>();
			TimersRemove = new List<TickTimer>();
			TimersTick = new List<TickTimer>();
			GridSize = gridSize;
			Size = size;

			Cells = new Cell[((uint)size.X), ((uint)size.Y)];

			for (uint x = 0; x < ((uint)size.X); x++) {
				for (uint y = 0; y < ((uint)size.Y); y++) {
					Cells[x, y] = new Cell(new Vector2(x, y));
				}
			}
		}

		public void SetEntityCellPos(Entity ent, Vector2? LastPos, Vector2? NewPos) {
			if (LastPos != null)
				GetCellOrNull(LastPos.Value)?.Entities.Remove(ent);

			if (NewPos != null)
				GetCellOrNull(NewPos.Value)?.Entities.Add(ent);
		}

		public Entity? FindFirstEnt<T>(Entity thisEnt){
			Entity? min = null;

			foreach (var ent in EntsTick) {
				if (ent is T) {
					if (min != null) {
						if ((ent.GetPos() - thisEnt.GetPos()).Length() < (min.GetPos() - thisEnt.GetPos()).Length()) {
							min = ent;
						}
					} else
						min = ent;
				}
			}

			return min;
		}

		private Cell? GetCellOrNull(Vector2 pos) {
			pos -= new Vector2(0.5f);

			pos.X = (float)Math.Truncate(pos.X);
			pos.Y = (float)Math.Truncate(pos.Y);

			if (pos.X < 0 || pos.Y < 0 || pos.Y >= Size.X || pos.X >= Size.X)
				return null;

			return Cells[(uint)pos.X, (uint)pos.Y];
		}

		public void AddTickEnt(Entity ent) {
			EntsTick.Add(ent);
		}

		public void RemoveTickEnt(Entity ent) {
			EntsRemove.Add(ent);
		}

		public void AddTickTimer(TickTimer tmr) {
			TimersTick.Add(tmr);
		}

		public void RemoveTickTimer(TickTimer tmr) {
			TimersRemove.Add(tmr);
		}
		
		public void RemoveOldTimer() {
			foreach (TickTimer tmr in TimersRemove) {
				TimersTick.Remove(tmr);
			}

			TimersRemove.Clear();
		}

		public void TickTimers() {
			foreach (TickTimer tmr in TimersTick) {
				tmr.Tick();
			}
		}

		public void RemoveOldEnts() {
			foreach (Entity ent in EntsRemove) {
				EntsTick.Remove(ent);

				this.SetEntityCellPos(ent, ent.GetPos(), null);
			}

			EntsRemove.Clear();
		}
	}
}
