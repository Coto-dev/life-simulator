using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace life_simulator {
	public partial class Form1 : Form {
		public Render.Render Render { get; }
		public Render.World World { get; }
		private PictureBox PictureBox { get; }
		public Form1() {
			InitializeComponent();

			PictureBox = new PictureBox();
			PictureBox.Dock = DockStyle.Fill;
			PictureBox.BackColor = Color.Black;

			Vector2 Grid = new Vector2(10, 10);
			Vector2 GridMultiplier = new Vector2(20, 20);

			Render = new Render.Render(PictureBox);
			World = new Render.World(Grid, GridMultiplier);

			PictureBox.Paint += new PaintEventHandler((object sender, PaintEventArgs e) => {
				Render.drawWorld(e, World);
			});

			Vector2 windowSize = Grid * GridMultiplier;

			this.Controls.Add(PictureBox);
			this.Size = new Size((int)windowSize.X, (int)windowSize.Y);

			SceneTest.Create(World);
		}
	}
}