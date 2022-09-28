using life_simulator.Render;
using System.Drawing;
using System.Numerics;

namespace life_simulator.Classes {
	public class Entity {
		public EntityRender Render { get; } = new();

		protected Vector2 Pos = new(1f);
		protected Vector2 Vel = new(0f);
		protected bool isFreezed = false;
		protected World World;
		protected uint Ticks = 0;

		public Entity(World world) {
			this.World = world;
			this.World.AddTickEnt(this);

			this.Render.SetColor(Color.FromArgb(unchecked((int)0xffff0000)));
			this.Render.SetSize(this.World.GridSize / 2);
			this.Render.SetSvg("assets/svg/Debug.svg");
			this.Render.Rerender();
		}

		public virtual void SetPos(Vector2 newPos) {
			this.World.SetEntityCellPos(this, this.Pos, newPos);

			this.Pos = newPos;
		}

		public virtual void SetVel(Vector2 newVel) {
			this.Vel = newVel;
		}

		public virtual void SetFreeze(bool freeze) {
			this.isFreezed = freeze;
		}

		public virtual Vector2 GetPos() {
			return this.Pos;
		}
		public virtual Vector2 GetVel() {
			return this.Vel;
		}
		public virtual bool GetFreeze() {
			return this.isFreezed;
		}

		public virtual void Tick() {
			if (!this.isFreezed) {
				this.SetPos(this.GetPos() + this.GetVel());
			}

			this.Ticks++;
		}

		public virtual void Remove() {
			this.World.RemoveTickEnt(this);
		}
	}
}
