namespace MasterMindForm {
    internal class TransparentPanel : Panel {
        public TransparentPanel() {
            this.SetStyle(ControlStyles.Opaque, true);
        }
        protected override void OnPaintBackground(PaintEventArgs e) {
            // Do not call base.OnPaintBackground(e) to prevent background painting
        }
        protected override void OnPaint(PaintEventArgs e) {
            using (SolidBrush brush = new(Color.FromArgb(128, Color.White))) // Adjust transparency here
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }
    }
}
