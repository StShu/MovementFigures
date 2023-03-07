using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovementFigures
{
    internal class Rectangle : Figure
    {
        public Rectangle(int x, int y, int width, int height, int stepMove, Directs direct, Brush brushes) : base(x, y, width, height, stepMove, direct, brushes) {}

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brushes, rectangle);
        }
    }
}
