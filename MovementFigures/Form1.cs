using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovementFigures
{
    public partial class Form1 : Form
    {
        public List<MovementFigures.Figure> FiguresList = new List<Figure>();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.pictureBox1.CreateGraphics();
            FiguresList.Insert(0,new MovementFigures.Rectangle(0, pictureBox1.Height / 2 - 50, 50, 50, 3, Figure.Directs.RIGHT, Brushes.Red));
            FiguresList.Insert(1, new MovementFigures.Rectangle(pictureBox1.Width-50, pictureBox1.Height / 2 - 50, 50, 50, 3, Figure.Directs.LEFT, Brushes.Black));

            for (int i = 0; i < 20; i++)
            {
                graphics.Clear(Color.White);


                foreach (var figure in FiguresList)
                {
                    figure.Move();
                    figure.Draw(graphics);
                }
                Thread.Sleep(50);

            }
        }
    }
}
