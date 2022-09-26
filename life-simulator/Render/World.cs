﻿using System;
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
			if (LastPos != null) {
				Vector2 LastPosToGrid = LastPos.Value / this.GridSize;

				GetCellOrNull(((uint)(LastPosToGrid.X)), ((uint)LastPosToGrid.Y))?.Entities.Remove(ent);
			}

			if (NewPos != null) {
				Vector2 NewPosToGrid = NewPos.Value / this.GridSize;

				GetCellOrNull(((uint)NewPosToGrid.X), ((uint)NewPosToGrid.Y))?.Entities.Add(ent);
			}
		}

		private Cell? GetCellOrNull(uint x, uint y) {
			if (x < 0 || y < 0 || y >= Size.X || x >= Size.X)
				return null;

			return Cells[x, y];
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
