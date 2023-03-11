using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementFigures
{
    internal abstract class Shape

    {
        public enum Directs
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        public System.Drawing.Rectangle rectangle;
        public int StepMove { get; }
        public Directs Direct { get; private set; }
        public Brush Brush { get; private set; }

        protected Shape(System.Drawing.Rectangle rectangle,Directs direct, Brush brush, int step)
        {
            this.Direct = direct;
            this.Brush = brush;
            this.StepMove = step;
            this.rectangle = rectangle;
        }

        protected Shape(int x, int y, int width, int height, int step, Directs direct, Brush brush)
        {
            this.StepMove = step;
            this.Direct = direct;
            this.Brush = brush;
            this.rectangle = new System.Drawing.Rectangle(x, y, width, height);
        }

        public void SetDirect(Directs direct)
        {
            this.Direct = direct;
        }

        public void setBrush(Color color)
        {
            this.Brush = new SolidBrush(color);
        }

        public abstract void Draw(Graphics graphics);
        public abstract void ToggleDirect();
    }
}
