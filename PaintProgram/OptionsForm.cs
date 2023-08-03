using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintProgram
{
    public partial class OptionsForm : Form
    {
        public delegate void ChangeColor(Color color);
        public delegate void ChangePenSize(float size);

        private readonly ChangeColor _changeColor;
        private readonly ChangePenSize _changePenSize;

        public OptionsForm(ChangeColor changeColor, ChangePenSize changePenSize, float penSize)
        {
            InitializeComponent();

            _changeColor = changeColor;
            _changePenSize = changePenSize;
            numericUpDown1.Value = Convert.ToDecimal(penSize);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            _changeColor(Color.Black);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            _changeColor(Color.Red);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var numericUpDown = (NumericUpDown)sender;

            _changePenSize((float)numericUpDown.Value);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            _changeColor(Color.Yellow);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            _changeColor(Color.White);
        }
    }
}
