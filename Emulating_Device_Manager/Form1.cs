using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emulating_Device_Manager
{
    public partial class Form1 : Form
    {
        private Searcher _searcher;
        public Form1()
        {
            InitializeComponent();
            _searcher = new Searcher();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _searcher.DriverOutput();
        }
    }
}
