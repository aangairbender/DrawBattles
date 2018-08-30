using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawBattles
{
    public partial class MainForm : Form
    {
        private Graphics _graphics;
        private Bitmap _bitmap;

        public MainForm()
        {
            InitializeComponent();
            Point p;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(_bitmap);
        }
    }
}
