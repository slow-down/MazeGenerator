using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class Form1 : Form
    {
        private MazeGenerator maze;
        private Pen red = new Pen(Color.Red, 2);

        public Form1()
        {
            InitializeComponent();
            Frm.form = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maze = new MazeGenerator();
        }


        public PictureBox PictureBox1()
        {
            return pictureBox1;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_spacing.Text)) return;

            int spacing = Convert.ToInt32(txt_spacing.Text);
            maze.Start(pictureBox1.Width, pictureBox1.Height, spacing);
            maze.Draw(pictureBox1.Height, pictureBox1.Height);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

            maze.Draw(pictureBox1.Height, pictureBox1.Height);
        }



    }
}
