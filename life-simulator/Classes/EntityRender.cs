using Svg;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Numerics;

namespace life_simulator.Classes {
	public class EntityRender {
		protected Color Color = Color.FromArgb(unchecked((int)0xffffffff));
		protected Vector2 Size = new(5, 5);
		protected int Thickness = 3;
		protected Bitmap? Bitmap;
		protected object? Img;

		public EntityRender() {
			this.Rerender();
		}

		public void SetSize(Vector2 newSize) {
			this.Size = newSize;
		}
		public void SetColor(Color newColor) {
			this.Color = newColor;
		}
		public void SetThickness(int newThickness) {
			this.Thickness = newThickness;
		}

		public Color GetColor() {
			return this.Color;
		}
		public Vector2 GetSize() {
			return this.Size;
		}
		public int GetThickness() {
			return this.Thickness;
		}

		public void SetEntityRender(EntityRender entR) {
			this.Thickness = entR.Thickness;
			this.Color = entR.Color;
			this.Size = entR.Size;
			this.Bitmap = entR.Bitmap;
			this.Img = entR.Img;
		}

		public void SetSvg(string Path) {
			this.Img = SvgDocument.Open(Path);
		}

		public void SetImg(string Path) {
			this.Img = Image.FromFile(Path);
		}

		private static Bitmap ResizeImage(Image image, int width, int height) {
			Rectangle destRect = new(0, 0, width, height);
			Bitmap? destImage = new(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (Graphics? graphics = Graphics.FromImage(destImage)) {
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using ImageAttributes? wrapMode = new();

				wrapMode.SetWrapMode(WrapMode.TileFlipXY);
				graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
			}

			return destImage;
		}

		public void Rerender() {
			if (this.Bitmap != null) {
				this.Bitmap.Dispose();
			}

			if (this.Img is SvgDocument svgDocument) {
				svgDocument.Fill = new SvgColourServer(this.Color);
				this.Bitmap = svgDocument.Draw((int)this.Size.X, (int)this.Size.Y);
			} else if (this.Img is Image image) {
				this.Bitmap = ResizeImage(image, (int)this.Size.X, (int)this.Size.Y);
			} else if (this.Img is Bitmap bitmap) {
				this.Bitmap = bitmap;
			} else if (this.Img is null) {
				this.Bitmap = new Bitmap((int)this.Size.X, (int)this.Size.Y);

				Pen entPen = new(this.Color, this.Thickness);
				Graphics Graphics = Graphics.FromImage(this.Bitmap);
				Graphics.DrawRectangle(entPen, 0, 0, this.Size.X, this.Size.Y);
				Graphics.Dispose();
				entPen.Dispose();
			}
		}

		public Bitmap Draw() {
			return this.Bitmap!;
		}
	}
}
