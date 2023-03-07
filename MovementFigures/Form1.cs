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
                if (figure.rectangle.X <= pictureBox1.Width - figure.Width && figure.Direct == Figure.Directs.RIGHT)
                    return;
                if (figure.rectangle.X >= figure.rectangle.Width && figure.Direct == Figure.Directs.LEFT)
                    return;
            }


            if (figure is Сircle)
            {
                if (figure.rectangle.Y <= pictureBox1.Height - figure.Height && figure.Direct == Figure.Directs.DOWN)
                    return;
                if (figure.rectangle.Y >= figure.rectangle.Height && figure.Direct == Figure.Directs.UP)
                    return;
            }

           

            figure.ToggleDirect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var figure in FiguresList)
            {
                CheckedBorder(figure);
                figure.Move();
            }

            timer1.Interval = 100;
            Invalidate();
        }
      
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var figure in FiguresList)
                figure.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FiguresList.Add(new MovementFigures.Rectangle(1, base.Width / 2, 50, 50, 32, Figure.Directs.RIGHT, Brushes.Red));
            FiguresList.Add(new MovementFigures.Rectangle(base.Width - 51, base.Height / 2, 50, 50, 32, Figure.Directs.LEFT, Brushes.Black));
            FiguresList.Add(new MovementFigures.Сircle(base.Width / 2, 50, 50, 50, 32, Figure.Directs.DOWN, Brushes.Yellow));
            FiguresList.Add(new MovementFigures.Сircle(base.Width / 2, base.Height - 50, 50, 50, 32, Figure.Directs.UP, Brushes.Green));

        }
    }
}
