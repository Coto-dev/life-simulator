using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace life_simulator {
	public partial class Form1 : Form {
		public Timer gpuTimer;

		public Render.Render Render { get; }
		public Render.World World { get; }
		private PictureBox PictureBox { get; }
		public Form1() {
			this.InitializeComponent();
			AllocConsole();

			System.IO.Directory.SetCurrentDirectory("../../../"); // visual fix relactive path

			this.PictureBox = new();
			this.PictureBox.Dock = DockStyle.Fill;
			this.PictureBox.BackColor = Color.Black;

			Vector2 GridMultiplier = new(100, 100);
			Vector2 Grid = new(10, 10);

			this.World = new(Grid, GridMultiplier);
			this.Render = new(this.World);

			this.PictureBox.Paint += new((object sender, PaintEventArgs e) => {
				this.Render.DrawWorld(e);
			});

			this.gpuTimer = new();
			this.gpuTimer.Interval = 16;
			this.gpuTimer.Tick += (object? sender, EventArgs e) => {
				if (this.PictureBox.Image != null) {
					this.PictureBox.Image.Dispose();
					this.PictureBox.Image = null;
				}

				this.PictureBox.Refresh();
			};

			Vector2 windowSize = Grid * GridMultiplier + new Vector2(1f);

			this.Controls.Add(this.PictureBox);
			this.ClientSize = new((int)windowSize.X, (int)windowSize.Y);
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;


			SceneAnimal.Create(this.World);

			//ScenePlantTest.Create(World);


			this.gpuTimer.Start();
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();

		private void Form1_Load(object sender, EventArgs e) {

		}
	}
}