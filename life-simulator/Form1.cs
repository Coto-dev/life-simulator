using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Numerics;
using System;

namespace life_simulator {
	public partial class Form1 : Form {
		public Timer gpuTimer;

		public Render.Render Render { get; }
		public Render.World World { get; }
		private PictureBox PictureBox { get; }
		public Form1() {
			InitializeComponent();
			AllocConsole();

			PictureBox = new PictureBox();
			PictureBox.Dock = DockStyle.Fill;
			PictureBox.BackColor = Color.Black;

			Vector2 Grid = new Vector2(10, 10);
			Vector2 GridMultiplier = new Vector2(100, 100);

			Render = new Render.Render(PictureBox);
			World = new Render.World(Grid, GridMultiplier);

			PictureBox.Paint += new PaintEventHandler((object sender, PaintEventArgs e) => {
				Render.drawWorld(e, World);
			});

			gpuTimer = new Timer();
			gpuTimer.Interval = 16;
			gpuTimer.Tick += (object ?sender, EventArgs e) => {
				if (PictureBox.Image != null) {
					PictureBox.Image.Dispose();
					PictureBox.Image = null;
				}

				PictureBox.Refresh();
			};

			Vector2 windowSize = Grid * GridMultiplier;

			this.Controls.Add(PictureBox);
			this.Size = new Size((int)windowSize.X, (int)windowSize.Y);

			SceneTest.Create(World);

			gpuTimer.Start();
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();
	}
}