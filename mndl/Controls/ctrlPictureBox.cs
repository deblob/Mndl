using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mndl.Controls
{
    public class SelectionBoxEventArgs : EventArgs
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double MiddleX
        {
            get { return X + Width / 2; }
        }

        public double MiddleY
        {
            get { return Y + Height / 2; }
        }
    }

    public class ctrlPictureBox : PictureBox
    {
        private bool _isLeftMouseDown;
        private Point _lastInitialMouseDownLocation;
        private Point _lastMouseDownLocation;
        private Stopwatch _doubleClickTimer = new Stopwatch();

        public event Action<KeyPressEventArgs> KeyPress;
        public event Action<SelectionBoxEventArgs> SelectionBoxDrawn;

        public InterpolationMode InterpolationMode { get; set; }
        public Color SelectionBoxColor { get; set; } = Color.Red;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.InterpolationMode = InterpolationMode;
            base.OnPaint(e);

            if (_isLeftMouseDown)
            {
                g.DrawRectangle(new Pen(Color.Red),
                    _lastInitialMouseDownLocation.X,
                    _lastInitialMouseDownLocation.Y,
                    Math.Max(_lastMouseDownLocation.X - _lastInitialMouseDownLocation.X, 10),
                    Math.Max(_lastMouseDownLocation.X - _lastInitialMouseDownLocation.X, 10));
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            KeyPress?.Invoke(e);

            base.OnKeyPress(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isLeftMouseDown = true;
                _lastInitialMouseDownLocation = e.Location;
                _doubleClickTimer.Restart();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_isLeftMouseDown)
                {
                    double width = (double)(_lastMouseDownLocation.X - _lastInitialMouseDownLocation.X) / this.Width;
                    width = Math.Max(width, (double)10 / this.Width);

                    SelectionBoxEventArgs args = new SelectionBoxEventArgs()
                    {
                        X = (double)_lastInitialMouseDownLocation.X / this.Width,
                        Y = (double)_lastInitialMouseDownLocation.Y / this.Height,
                        Width = width,
                        Height = width
                    };

                    _doubleClickTimer.Stop();
                    this.Invalidate();
                    if (_doubleClickTimer.ElapsedMilliseconds > 100)
                        SelectionBoxDrawn?.Invoke(args);
                }

                _isLeftMouseDown = false;
            }

            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isLeftMouseDown)
            {
                _lastMouseDownLocation = e.Location;
                this.Invalidate();
            }

            base.OnMouseMove(e);
        }
    }
}
