﻿using System;
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
    public partial class AddOrUpdateForm : Form
    {
        public AddOrUpdateForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");

            const string SQL_INSERT_NEW_MEMBER = @"IF NOT EXISTS (SELECT 1
			                                                      FROM memberstable
			                                                      WHERE CardNumber = @CardNumber)
                                                   INSERT INTO memberstable
                                                   (FirstName, LastName, ScreenName, CardNumber, StartDate, EndDate)
                                                   VALUES(@FirstName, @LastName, @ScreenName, @CardNumber, @StartDate, @EndDate)";

            if (String.IsNullOrEmpty(textBox1.Text) ||
                String.IsNullOrEmpty(textBox2.Text) ||
                String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Popunite sva polja");
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand(SQL_INSERT_NEW_MEMBER, sqlConn))
                {
                    sqlConn.Open();

                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = textBox1.Text;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = textBox2.Text;
                    cmd.Parameters.Add("@ScreenName", SqlDbType.NVarChar, 50).Value = textBox1.Text + ' ' + textBox2.Text;
                    cmd.Parameters.Add("@CardNumber", SqlDbType.Int).Value = Int32.Parse(textBox3.Text);
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dateTimePicker2.Value;

                    cmd.ExecuteNonQuery();
                }

                this.Close();
            }
        }
    }
}