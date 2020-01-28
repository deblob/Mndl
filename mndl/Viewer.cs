using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mndl
{
    public partial class Viewer : Form
    {
        private readonly MandelComputer _previewComputer;
        private readonly MandelComputerCUDA _previewComputerCUDA;

        public Viewer()
        {
            InitializeComponent();
            _previewComputer = new MandelComputer();
            _previewComputerCUDA = new MandelComputerCUDA();
            pbViewNew.KeyPress += onViewKeyPress;
            pbViewNew.SelectionBoxDrawn += onSelectionBoxDrawn;
        }

        private void onViewKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    numYOffset.Value = numYOffset.Value - (decimal).1f * numScale.Value;
                    break;
                case 'a':
                    numXOffset.Value = numXOffset.Value - (decimal).1f * numScale.Value;
                    break;
                case 's':
                    numYOffset.Value = numYOffset.Value + (decimal).1f * numScale.Value;
                    break;
                case 'd':
                    numXOffset.Value = numXOffset.Value + (decimal).1f * numScale.Value;
                    break;
            }

            btnPreview_Click(this, null);
        }

        private double _currentLeftValue = -2;
        private double _currentRightValue = 2;
        private double _currentValueRange = 4;
        private void onSelectionBoxDrawn(Controls.SelectionBoxEventArgs e)
        {
            double newCenterX = (e.MiddleX * _currentValueRange) - (_currentValueRange / 2);
            double newCenterY = (e.MiddleY * _currentValueRange) - (_currentValueRange / 2);

            numXOffset.Value = (decimal)newCenterX;
            numYOffset.Value = (decimal)newCenterY;
            numScale.Value = numScale.Value * (decimal)e.Width;

            _currentValueRange *= e.Width;
            btnPreview_Click(this, null);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cbCuda.Checked)
            {
                _previewComputerCUDA.ResolutionWidth = (int)numPreviewWidth.Value;
                _previewComputerCUDA.ResolutionHeight = (int)numPreviewHeight.Value;
                _previewComputerCUDA.Iterations = (int)numIterations.Value;
                _previewComputerCUDA.ColorStart = clrStartNew.SelectedColor;
                _previewComputerCUDA.ColorEnd = clrEndNew.SelectedColor;
                _previewComputerCUDA.Scaling = numScale.Value;
                _previewComputerCUDA.OffsetX = numXOffset.Value;
                _previewComputerCUDA.OffsetY = numYOffset.Value;

                pbViewNew.Image = _previewComputerCUDA.Compute();
                pbViewNew.Image.Save("cuda_last_preview.png", ImageFormat.Png);
            }
            else
            {
                _previewComputer.ResolutionWidth = (int)numPreviewWidth.Value;
                _previewComputer.ResolutionHeight = (int)numPreviewHeight.Value;
                _previewComputer.Iterations = (int)numIterations.Value;
                _previewComputer.ColorStart = clrStartNew.SelectedColor;
                _previewComputer.ColorEnd = clrEndNew.SelectedColor;
                _previewComputer.Scaling = numScale.Value;
                _previewComputer.OffsetX = numXOffset.Value;
                _previewComputer.OffsetY = numYOffset.Value;

                barProgress.Maximum = _previewComputer.ResolutionWidth;
                //this.Enabled = false;

                Task.Factory.StartNew(() =>
                {
                    Bitmap result = _previewComputer.Compute(p =>
                    {
                        if (barProgress.InvokeRequired)
                            barProgress.Invoke(new MethodInvoker(() => barProgress.Value = p));
                        else
                            barProgress.Value = p;
                    });

                    this.Invoke(new MethodInvoker(() => this.Enabled = true));
                    pbViewNew.Invoke(new MethodInvoker(() => pbViewNew.Image = result));
                });
            }
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            string filePath = String.Empty;
            bool closed = false;
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    dlg.Filter = "PNG|*.png";
                    if (dlg.ShowDialog() == DialogResult.Cancel)
                    {
                        closed = true;
                        return;
                    }
                    filePath = dlg.FileName;
                }));
            }
            if (closed)
                return;

            _previewComputer.ResolutionWidth = (int)numRenderWidth.Value;
            _previewComputer.ResolutionHeight = (int)numRenderHeight.Value;
            _previewComputer.Iterations = (int)numIterations.Value;
            _previewComputer.ColorStart = clrStartNew.SelectedColor;
            _previewComputer.ColorEnd = clrEndNew.SelectedColor;
            _previewComputer.Scaling = numScale.Value;
            _previewComputer.OffsetX = numXOffset.Value;
            _previewComputer.OffsetY = numYOffset.Value;

            barProgress.Maximum = _previewComputer.ResolutionWidth;
            //this.Enabled = false;

            Task.Factory.StartNew(() =>
            {
                Bitmap result = _previewComputer.Compute(p =>
                {
                    if (barProgress.InvokeRequired)
                        barProgress.Invoke(new MethodInvoker(() => barProgress.Value = p));
                    else
                        barProgress.Value = p;
                });

                this.Invoke(new MethodInvoker(() => this.Enabled = true));
                result.Save(filePath);
            });
        }

        private void pbViewNew_MouseClick(object sender, MouseEventArgs e)
        {
            pbViewNew.Focus();
        }
    }
}
