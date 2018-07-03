using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace MazeGenerator
{
    public class MazeGenerator
    {
        private int height;
        private int width;
        private int spacing;

        public static Random rnd = new Random();
        private Bitmap bitmap = new Bitmap(1, 1);
        public Graphics g;

        private List<Cell> cells = new List<Cell>();

        public MazeGenerator()
        {

        }

        public void Start(int width, int height, int spacing)
        {
            cells.Clear();
            this.width = width;
            this.height = height;
            this.spacing = spacing;

            for (int y = 0; y < height / spacing; y++)
            {
                for (int x = 0; x < width / spacing; x++)
                {
                    cells.Add(new Cell(x, y, spacing));
                }
            }

            cells[0].visited = true;
            Generate(0, 0);
        }

        public void Draw(int width, int height)
        {
            bitmap.Dispose();
            bitmap = new Bitmap(width, height);
            g = Graphics.FromImage(bitmap);

            double scale = height / (double)this.height;

            foreach (Cell cell in cells)
            {
                cell.spacing = (int)(this.spacing * scale);
                cell.Draw(g);
            }
            Update();

            //g.DrawRectangle(new Pen(Color.Black, 1), 0, 0, width - 1, height - 1);
        }

        private void Generate(int x, int y)
        {
            int[] dirs = GenerateRandomDirections();

            foreach (int dir in dirs)
            {
                switch (dir)
                {
                    case 0: // top
                        if (y <= 0) continue;
                        if (cells[index(x, y - 1)].visited) continue;

                        cells[index(x, y - 1)].visited = true;
                        cells[index(x, y)].walls[0] = false;
                        cells[index(x, y - 1)].walls[2] = false;
                        Generate(x, y - 1);
                        break;
                    case 1: // right
                        if (x >= (width / spacing) - 1) continue;
                        if (cells[index(x + 1, y)].visited) continue;

                        cells[index(x + 1, y)].visited = true;
                        cells[index(x, y)].walls[1] = false;
                        cells[index(x + 1, y)].walls[3] = false;
                        Generate(x + 1, y);
                        break;
                    case 2: // bottom
                        if (y >= (height / spacing) - 1) continue;
                        if (cells[index(x, y + 1)].visited) continue;

                        cells[index(x, y + 1)].visited = true;
                        cells[index(x, y)].walls[2] = false;
                        cells[index(x, y + 1)].walls[0] = false;
                        Generate(x, y + 1);
                        break;
                    case 3: // left
                        if (x <= 0) continue;
                        if (cells[index(x - 1, y)].visited) continue;

                        cells[index(x - 1, y)].visited = true;
                        cells[index(x, y)].walls[3] = false;
                        cells[index(x - 1, y)].walls[1] = false;
                        Generate(x - 1, y);
                        break;
                    default:
                        return;
                }


            }

        }

        public void Update()
        {
            Frm.form.PictureBox1().Image = bitmap;
        }

        private int index(int x, int y)
        {
            return ((y * (width / spacing)) + x);
        }

        private int[] GenerateRandomDirections()
        {
            List<int> nums = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                nums.Add(i);
            }
            nums.Shuffle();
            return nums.ToArray();
        }

    }

    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = MazeGenerator.rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
