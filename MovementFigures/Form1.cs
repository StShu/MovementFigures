using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;

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
                if (figure.rectangle.X <= base.Width - figure.Width && figure.Direct == Figure.Directs.RIGHT)
                    return;
                if (figure.rectangle.X >= figure.rectangle.Width && figure.Direct == Figure.Directs.LEFT)
                    return;
            }


            if (figure is Сircle)
            {
                if (figure.rectangle.Y <= base.Height - figure.Height && figure.Direct == Figure.Directs.DOWN)
                    return;
                if (figure.rectangle.Y >= figure.rectangle.Height && figure.Direct == Figure.Directs.UP)
                    return;
            }

            figure.ToggleDirect();
        }

        public void CheckedIntersection(MovementFigures.Figure figure)
        {
            if (figure is Сircle)
            {
                if (figure.rectangle.Y < 320 && figure.Direct == Figure.Directs.DOWN)
                    return;
                if (figure.rectangle.Y > 320 && figure.Direct == Figure.Directs.UP)
                    return;
                FiguresList.Where(c => c is Rectangle).ToList().ForEach(c => { c.setBrush(Color.Blue); });
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 99;
            Invalidate();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            FiguresList[3].Draw(e.Graphics);
            foreach (var figure in FiguresList)
                figure.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FiguresList.Add(new MovementFigures.Rectangle(1, base.Width / 2, 50, 50, 30, Figure.Directs.RIGHT, Brushes.Red,1));
            FiguresList.Add(new MovementFigures.Rectangle(base.Width - 51, base.Height / 2, 50, 50, 20, Figure.Directs.LEFT, Brushes.Black,2));
            FiguresList.Add(new MovementFigures.Сircle(base.Width / 2, 50, 50, 50, 10, Figure.Directs.DOWN, Brushes.Yellow,1));
            FiguresList.Add(new MovementFigures.Сircle(base.Width / 2, base.Height - 50, 50, 50, 10, Figure.Directs.UP, Brushes.Green,2));
        }

        public void MoveFigure(object? giFigure)
        {
            if (giFigure is Figure figure)
            {
                while (true)
                {
                    Thread.Sleep(100);
                    CheckedIntersection(figure);
                    CheckedBorder(figure);
                    figure.Move();
                    //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    
                }
            }
        }

        public void ListenCommandPipe()
        {
           
            using (var pipeClient =
                   new NamedPipeClientStream("RealtimeOSpipe"))
            {
                Label label = new Label();
                label.Location = new System.Drawing.Point(300, 20);

                label.Size = new System.Drawing.Size(77, 21);
                Controls.Add(label);
                // Connect to the pipe or wait until the pipe is available.
                Console.Write("Attempting to connect to pipe...");
                pipeClient.Connect();

                Console.WriteLine("Connected to pipe.");
                Console.WriteLine("There are currently {0} pipe server instances open.",
                    pipeClient.NumberOfServerInstances);
                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    
                    // Display the read text to the console
                    string temp;
                    while ((temp = sr.ReadLine()) != null)
                    {
                        label.Text = temp;
                        string[] words = temp.Split(' ');

                        Figure figure = null;
                        if (words[0].ToLower() == "rectangle")
                        {
                            figure = FiguresList.Where(f => f.id == Convert.ToInt32(words[1]) && f is Rectangle)
                                .Single();
                        }
                        else if (words[0].ToLower() == "circle")
                        {
                            figure = FiguresList.Where(f => f.id == Convert.ToInt32(words[1]) && f is Сircle).Single();

                        }

                        if (figure is Rectangle)
                        {
                            figure.rectangle.X += Convert.ToInt32(words[2]);
                        }else if (figure is Сircle)
                        {
                            figure.rectangle.Location = new Point(figure.x, figure.y);
                        }
                    }
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var myThread1 = new Thread(MoveFigure);
            var myThread2 = new Thread(MoveFigure);
            var myThread3 = new Thread(MoveFigure);
            var myThread4 = new Thread(MoveFigure);
            var myThread5 = new Thread(ListenCommandPipe);

            myThread1.Start(FiguresList[0]);
            myThread2.Start(FiguresList[1]);
            myThread3.Start(FiguresList[2]);
            myThread4.Start(FiguresList[3]);

            myThread5.Start();




        }

    }
}
