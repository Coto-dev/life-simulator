using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using life_simulator.Render;

namespace life_simulator.Classes {
	public class Entity {
		protected Color Color = Color.FromArgb(255, 255, 0, 0);
		protected Vector2 Size = new Vector2(5, 5);
		protected Vector2 Pos = new Vector2(0, 0);
		protected Vector2 Vel = new Vector2(0, 0);
		protected bool isFreezed = false;
		protected World World;

		public Entity(World world) {
			World = world;

			World.AddTickEnt(this);
		}

		public void setPos(Vector2 newPos) {
			World.setEntityCellPos(this, Pos, newPos);

			Pos = newPos;
		}

		public void setVel(Vector2 newVel) {
			Vel = newVel;
		}

		public void setSize(Vector2 newSize) {
			Size = newSize;
		}

		public void setColor(Color newColor) {
			Color = newColor;
		}

		public void setFreeze(bool freeze) {
			isFreezed = freeze;
		}

		public Color getColor() {
			return Color;
		}
		public Vector2 getSize() {
			return Size;
		}
		public Vector2 getPos() {
			return Pos;
		}
		public Vector2 getVel() {
			return Vel;
		}
		public bool getFreeze() {
			return isFreezed;
		}

		public void Tick() {
			if(!isFreezed)
				this.setPos(this.getPos() + this.getVel());
		}

		public void Remove() {
			World.RemoveTickEnt(this);
		}
	}
}
