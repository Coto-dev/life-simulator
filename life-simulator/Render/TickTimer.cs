using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace life_simulator.Render {
	public class TickTimer {
		public uint TicksCount = 0;
		public uint Ticks = 0;
		public uint TickItr;
		public uint Repeat;
		public World World;
		public Action<uint> Cb;

		public TickTimer(World world, Action<uint> cb, uint tick, uint repeat) {
			Cb = cb;
			World = world;
			TickItr = tick;
			Repeat = repeat == 0 ? uint.MaxValue : repeat;

			World.AddTickTimer(this);
		}

		public void Tick() {
			TicksCount++;

			if (++Ticks >= TickItr) {
				Cb(TicksCount);

				Ticks = 0;
				Repeat--;
			}

			if (Repeat == 0) {
				World.RemoveTickTimer(this);
			}
		}

		public void Destroy() {
			World.RemoveTickTimer(this);
		}
	}
}
