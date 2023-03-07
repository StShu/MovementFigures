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
using System.Windows.Forms.VisualStyles;

namespace MovementFigures
{
    public partial class Form1 : Form
    {
        public List<MovementFigures.Figure> FiguresList = new List<Figure>();

        public Form1()
        {
            InitializeComponent();
        }

        public void CheckedBorder(MovementFigures.Figure figure)
        {
            if (figure is Rectangle)
            {
                if (figure.x <= pictureBox1.Width - figure.Width && figure.Direct == Figure.Directs.RIGHT)
                    return;
                if (figure.x >=0 && figure.Direct == Figure.Directs.LEFT)
                    return;
            }


            if (figure is Сircle)
            {
                if (figure.y <= pictureBox1.Height - figure.Height && figure.Direct == Figure.Directs.DOWN)
                    return;
                if (figure.y >= 0 && figure.Direct == Figure.Directs.UP)
                    return;
            }

           

            figure.ToggleDirect();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.pictureBox1.CreateGraphics();

            FiguresList.Add(new MovementFigures.Rectangle(1, 300, 50, 50, 32, Figure.Directs.RIGHT, Brushes.Red));
            FiguresList.Add(new MovementFigures.Rectangle(300, pictureBox1.Height / 2, 50, 50, 32, Figure.Directs.LEFT, Brushes.Black));
            FiguresList.Add(new MovementFigures.Сircle(300, 50, 50, 50, 32, Figure.Directs.DOWN, Brushes.Yellow));
            FiguresList.Add(new MovementFigures.Сircle(300, 300, 50, 50, 32, Figure.Directs.UP, Brushes.Green));

            var i = FiguresList[1].GetType();
            while (true)
            {
                graphics.Clear(Color.White);
                foreach (var figure in FiguresList)
                {
                    CheckedBorder(figure);
                    figure.Move();
                    figure.Draw(graphics);
                }
                Thread.Sleep(50);

            }
        }
    }
}
