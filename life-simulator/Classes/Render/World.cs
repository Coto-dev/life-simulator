using life_simulator.Classes;
using System;
using System.Collections.Generic;
using System.Numerics;

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
			this.EntsRemove = new List<Entity>();
			this.EntsTick = new List<Entity>();
			this.TimersRemove = new List<TickTimer>();
			this.TimersTick = new List<TickTimer>();
			this.GridSize = gridSize;
			this.Size = size;

			this.Cells = new Cell[((uint)size.X), ((uint)size.Y)];

			for (uint x = 0; x < ((uint)size.X); x++) {
				for (uint y = 0; y < ((uint)size.Y); y++) {
					this.Cells[x, y] = new Cell(new Vector2(x, y));
				}
			}
		}

		public void SetEntityCellPos(Entity ent, Vector2? LastPos, Vector2? NewPos) {
			if (LastPos != null) {
				this.GetCellOrNull(LastPos.Value)?.Entities.Remove(ent);
			}

			if (NewPos != null) {
				this.GetCellOrNull(NewPos.Value)?.Entities.Add(ent);
			}
		}

		public Entity? FindFirstEnt<T1, T2>(Entity thisEnt) {
			Entity? min = null;

			foreach (Entity? ent in this.EntsTick) {
				if (ent is T1 || ent is T2) {
					if (min != null) {
						if ((ent.GetPos() - thisEnt.GetPos()).Length() < (min.GetPos() - thisEnt.GetPos()).Length()) {
							min = ent;
						}
					} else {
						min = ent;
					}
				}
			}

			return min;
		}

		public bool IsCellEmpty(Vector2 Coords) {
			Cell? result = this.GetCellOrNull(Coords);
			if (result == null) {
				return true;
			}
			return result.Entities.Count == 0;
		}

		private Cell? GetCellOrNull(Vector2 pos) {
			pos -= new Vector2(0.5f);

			pos.X = (float)Math.Truncate(pos.X);
			pos.Y = (float)Math.Truncate(pos.Y);

			if (pos.X < 0 || pos.Y < 0 || pos.Y >= this.Size.X || pos.X >= this.Size.X) {
				return null;
			}

			return this.Cells[(uint)pos.X, (uint)pos.Y];
		}

		public void AddTickEnt(Entity ent) {
			this.EntsTick.Add(ent);
		}

		public void RemoveTickEnt(Entity ent) {
			this.EntsRemove.Add(ent);
		}

		public void AddTickTimer(TickTimer tmr) {
			this.TimersTick.Add(tmr);
		}

		public void RemoveTickTimer(TickTimer tmr) {
			this.TimersRemove.Add(tmr);
		}

		public void RemoveOldTimer() {
			foreach (TickTimer tmr in this.TimersRemove) {
				this.TimersTick.Remove(tmr);
			}

			this.TimersRemove.Clear();
		}

		public void TickTimers() {
			foreach (TickTimer tmr in this.TimersTick) {
				tmr.Tick();
			}
		}

		public void RemoveOldEnts() {
			foreach (Entity ent in this.EntsRemove) {
				this.EntsTick.Remove(ent);

				this.SetEntityCellPos(ent, ent.GetPos(), null);
			}

			this.EntsRemove.Clear();
		}
	}
}
