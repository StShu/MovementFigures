using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovementFigures
{
    internal class Сircle: Figure
    {
        public Сircle(int x, int y, int width, int height, int stepMove, Directs directs, Brush brushes) : base(x, y, width, height, stepMove, directs, brushes) { }

        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(brushes, rectangle);
        }
    }
}
