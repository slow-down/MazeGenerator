using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MazeGenerator
{
    public class Cell
    {
        public bool[] walls = { true, true, true, true }; // top, right, bottom, left
        public bool[] dirs = { false, false, false, false }; // top, right, bottom, left
        public bool visited = false;
        public int spacing = 0;

        private int x = 0;
        private int y = 0;

        private static Pen pen = new Pen(Color.Black, 1);

        public Cell(int x, int y, int spacing)
        {
            this.x = x;
            this.y = y;
            this.spacing = spacing;
        }

        public void Draw(Graphics g)
        {
            int x = this.x * spacing;
            int y = this.y * spacing;

            if (walls[0]) // top
            {
                g.DrawLine(pen, x, y, x + spacing, y);
            }
            if (walls[1]) // right
            {
                g.DrawLine(pen, x + spacing, y, x + spacing, y + spacing);
            }
            if (walls[2]) // bottom
            {
                g.DrawLine(pen, x, y + spacing, x + spacing, y + spacing);
            }
            if (walls[3]) // left
            {
                g.DrawLine(pen, x, y, x, y + spacing);
            }
        }

    }
}
