using System;

namespace life_simulator.Render {
	public class TickTimer {
		private uint TicksCount = 0;
		private uint Ticks = 0;
		private uint TickItr;
		private uint Repeat;
		private World World;
		private Action<uint> Cb;

		public TickTimer(World world, Action<uint> cb, uint tick, uint repeat) {
			this.Cb = cb;
			this.World = world;
			this.TickItr = tick;
			this.Repeat = repeat == 0 ? uint.MaxValue : repeat;

			this.World.AddTickTimer(this);
		}

		public virtual void Tick() {
			this.TicksCount++;

			if (++this.Ticks >= this.TickItr) {
				this.Cb(this.TicksCount);

				this.Ticks = 0;
				this.Repeat--;
			}

			if (this.Repeat == 0) {
				this.World.RemoveTickTimer(this);
			}
		}

		public virtual void Destroy() {
			this.World.RemoveTickTimer(this);
		}
	}
}
