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
    public partial class Form1 : Form
    {
        int x, y = -1;
        bool isDrawing;


        Graphics panelGraphics;
        Graphics bitmapGraphics;

        Pen pen;

        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();

            panelGraphics = panelCanvas.CreateGraphics();
            panelGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pen = new Pen(Color.Black, 3);
            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);


            bitmap = new Bitmap(panelCanvas.Width, panelCanvas.Height);
            bitmapGraphics = Graphics.FromImage(bitmap);

            panelCanvas.BackgroundImage = bitmap;
            panelCanvas.BackgroundImageLayout = ImageLayout.None;
            
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            isDrawing = true;

        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            x = y = -1;
            isDrawing = false;
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm(ChangeColor, ChangePenSize, pen.Width);
            optionsForm.Show();
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && x != -1 && y != -1 )
            {
                panelGraphics.DrawLine(pen, new Point(x, y), new Point(e.X, e.Y));
                bitmapGraphics.DrawLine(pen, new Point(x, y), new Point(e.X, e.Y));
                x = e.X;
                y = e.Y;
            }
        }

        private void ChangeColor(Color color)
        {
            pen.Color = color;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Png Files (*.png) | *.png";
            saveFileDialog.DefaultExt = "png";
            saveFileDialog.AddExtension = true;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filename = saveFileDialog.FileName;
                bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void ChangePenSize(float size)
        {
            pen.Width = size;
        }
    }
}
