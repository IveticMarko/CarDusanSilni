using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mmaTeamCDS_desktopApp
{
    public partial class Main : Form
    {
        public Boolean isAlreadyClickedExit = false;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isAlreadyClickedExit)
            {
                isAlreadyClickedExit = true;
                DialogResult dialog = MessageBox.Show("Da li želite da izađete iz aplikacije?", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                    isAlreadyClickedExit = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            userControl21.Hide();
            userControl11.Show();
            userControl11.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Show();
            userControl21.BringToFront();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}
