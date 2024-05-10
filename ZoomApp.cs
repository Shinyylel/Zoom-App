using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                MagnifierForm magnifier = new MagnifierForm();
                magnifier.Show();
            }
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            MagnifierForm magnifier = new MagnifierForm();
            magnifier.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
