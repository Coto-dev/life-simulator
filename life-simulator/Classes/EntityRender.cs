using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Svg;
using System.Numerics;

namespace life_simulator.Classes {
	public class EntityRender {
		protected Color Color = Color.FromArgb(unchecked((int)0xffffffff));
		protected Vector2 Size = new(5, 5);
		protected int Thickness = 3;
		protected Bitmap? Bitmap;
		protected object? Img;

		public EntityRender() {
			Rerender();
		}

		public void SetSize(Vector2 newSize) {
			Size = newSize;
		}
		public void SetColor(Color newColor) {
			Color = newColor;
		}
		public void SetThickness(int newThickness) {
			Thickness = newThickness;
		}

		public Color GetColor() {
			return Color;
		}
		public Vector2 GetSize() {
			return Size;
		}
		public int GetThickness() {
			return Thickness;
		}

		public void SetEntityRender(EntityRender entR) {
			Thickness = entR.Thickness;
			Color = entR.Color;
			Size = entR.Size;
			Bitmap = entR.Bitmap;
			Img = entR.Img;
		}

		public void SetSvg(string Path) {
			Img = SvgDocument.Open(Path);
		}

		public void Rerender() {
			if (Bitmap != null)
				Bitmap.Dispose();

			if (Img is SvgDocument svgDocument) {
				svgDocument.Fill = new SvgColourServer(Color);
				Bitmap = svgDocument.Draw((int)Size.X, (int)Size.Y);
			} else if (Img is Bitmap bitmap) {
				Bitmap = bitmap;
			} else if (Img is null) {
				Bitmap = new Bitmap((int)Size.X, (int)Size.Y);

				Pen entPen = new(Color, Thickness);
					Graphics Graphics = Graphics.FromImage(Bitmap);
						Graphics.DrawRectangle(entPen, 0, 0, Size.X, Size.Y);
					Graphics.Dispose();
				entPen.Dispose();
			}
		}

		public Bitmap Draw() {
			return Bitmap!;
		}
	}
}
