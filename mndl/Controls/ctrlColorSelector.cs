using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mndl.Controls
{
    public partial class ctrlColorSelector : UserControl
    {
        private Color _selectedColor;
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                this.BackColor = _selectedColor;
            }
        }

        public ctrlColorSelector(Color c)
        {
            InitializeComponent();
            SelectedColor = c;
        }

        public ctrlColorSelector()
            : this(Color.White)
        { }

        private void ctrlColorSelector_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                SelectedColor = dlg.Color;
            }
        }
    }
}
