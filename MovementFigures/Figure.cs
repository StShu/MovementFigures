using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovementFigures
{
    public abstract class Figure
    {
        public enum Directs
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

      
        public System.Drawing.Rectangle rectangle;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int id { get; set; }
        public int x { get; private set; }
        public int y { get; private set; }

        public int stepMove { get; }
        public Directs Direct { get; private set; }
        public Brush brushes { get; private set; }

        public event Action MyEvent;

        protected Figure(int x, int y, int width, int height, int stepMove,Directs direct, Brush brushes, int id)
        {
            this.x = x;
            this.y = y;
            this.Width = width;
            this.Height = height;
            this.stepMove = stepMove;
            this.Direct = direct;
            this.brushes = brushes;
            this.rectangle = new System.Drawing.Rectangle(x, y, width, height);
            this.id = id;
        }

        public void SetDirect(Directs direct)
        {   
            this.Direct = direct;
        }

        public void setBrush(Color color)
        {
            this.brushes = new SolidBrush(color);
        }

        public void Move()
        {
            switch (Direct)
            {
                case Directs.UP:
                    this.rectangle.Offset(0,-stepMove);

                    break;
                case Directs.DOWN:
                    this.rectangle.Offset(0, +stepMove);

                    break;
                case Directs.LEFT:
                    this.rectangle.Offset(-stepMove, 0);

                    break;
                case Directs.RIGHT:
                    this.rectangle.Offset(+stepMove, 0);
                    break;
            }
        }

        public abstract void Draw(Graphics graphics);
        public abstract void ToggleDirect();

        protected virtual void Updated()
        {
            MyEvent?.Invoke();
        }
    }
}
