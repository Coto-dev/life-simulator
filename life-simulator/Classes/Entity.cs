using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using life_simulator.Render;
using Svg;

namespace life_simulator.Classes {
	public class Entity {
		public EntityRender Render { get; } = new();

		protected Vector2 Pos = new(0, 0);
		protected Vector2 Vel = new(0, 0);
		protected bool isFreezed = false;
		protected World World;

		public Entity(World world) {
			World = world;
			World.AddTickEnt(this);

			Render.SetColor(Color.FromArgb(unchecked((int)0xffff0000)));
			Render.SetSize(new Vector2(20, 20));
			Render.SetSvg("assets/svg/Debug.svg");
			Render.Rerender();
		}

		public void SetPos(Vector2 newPos) {
			World.SetEntityCellPos(this, Pos, newPos);

			Pos = newPos;
		}

		public void SetVel(Vector2 newVel) {
			Vel = newVel;
		}

		public void SetFreeze(bool freeze) {
			isFreezed = freeze;
		}
		
		public Vector2 GetPos() {
			return Pos;
		}
		public Vector2 GetVel() {
			return Vel;
		}
		public bool GetFreeze() {
			return isFreezed;
		}

		public void Tick() {
			if(!isFreezed)
				this.SetPos(this.GetPos() + this.GetVel());
		}

		public void Remove() {
			World.RemoveTickEnt(this);
		}
	}
}
