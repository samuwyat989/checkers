using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            letterLabel.Text = "a    b    c    d    e    f    g    h";
            BoardScreen bs = new BoardScreen();
            this.Controls.Add(bs);
            bs.Location = new Point((this.Width - bs.Width) / 2, (this.Height - bs.Height) / 2);
        }
    }
}
