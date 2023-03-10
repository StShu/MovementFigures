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
        public Сircle(int x, int y, int width, int height, int stepMove, Directs directs, Brush brushes, int id) : base(x, y, width, height, stepMove, directs, brushes, id) { }

        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(brushes, rectangle);
        }
        public override void ToggleDirect()
        {
            SetDirect(this.Direct == Directs.UP ? Directs.DOWN : Directs.UP);
        }
    }
}
