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

			System.IO.Directory.SetCurrentDirectory("../../../"); // visual fix relactive path

			PictureBox = new();
			PictureBox.Dock = DockStyle.Fill;
			PictureBox.BackColor = Color.Black;

			Vector2 GridMultiplier = new(100, 100);
			Vector2 Grid = new(10, 10);

			World = new(Grid, GridMultiplier);
			Render = new(World);

			PictureBox.Paint += new((object sender, PaintEventArgs e) => {
				Render.DrawWorld(e);
			});

			gpuTimer = new();
			gpuTimer.Interval = 16;
			gpuTimer.Tick += (object ?sender, EventArgs e) => {
				if (PictureBox.Image != null) {
					PictureBox.Image.Dispose();
					PictureBox.Image = null;
				}

				PictureBox.Refresh();
			};

			Vector2 windowSize = (Grid + new Vector2(0.175f, 0.4f)) * GridMultiplier;

			this.Controls.Add(PictureBox);
			this.Size = new((int)windowSize.X, (int)windowSize.Y);
			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			SceneAnimal.Create(World);

			gpuTimer.Start();
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();
	}
}