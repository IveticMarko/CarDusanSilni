using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mmaTeamCDS_desktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: Password should be encrypted!

            SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");
            const string SQL_LOGGIN = @"SELECT 1
                                        FROM usertable
                                        WHERE Username = @UserName
                                              AND Password = @Password";

            using (SqlCommand cmd = new SqlCommand(SQL_LOGGIN, sqlConn))
            {
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = (String.IsNullOrEmpty(textBox1.Text) ? "" : textBox1.Text);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = (String.IsNullOrEmpty(textBox2.Text) ? "" : textBox2.Text);

                sqlConn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        this.Hide();
                        Main mainForm = new Main();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Proverite korisničko ime i lozinku!");
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //TODO: Password should be encrypted!

                SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");
                const string SQL_LOGGIN = @"SELECT 1
                                        FROM usertable
                                        WHERE Username = @UserName
                                              AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(SQL_LOGGIN, sqlConn))
                {
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = (String.IsNullOrEmpty(textBox1.Text) ? "" : textBox1.Text);
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = (String.IsNullOrEmpty(textBox2.Text) ? "" : textBox2.Text);

                    sqlConn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            this.Hide();
                            Main mainForm = new Main();
                            mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Proverite korisničko ime i lozinku!");
                        }
                    }
                }
            }
        }
    }
}
