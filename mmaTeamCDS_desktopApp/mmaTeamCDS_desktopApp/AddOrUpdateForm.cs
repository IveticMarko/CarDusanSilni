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
    public partial class AddOrUpdateForm : Form
    {
        public Boolean isUpdateState = false;

        public AddOrUpdateForm()
        {
            InitializeComponent();

            button3.Hide();

            button4.Hide();
            textBox4.Hide();
        }

        public AddOrUpdateForm(RealMember member)
        {
            InitializeComponent();

            button1.Hide();
            textBox3.Enabled = false;

            textBox1.Text = member.FirstName;
            textBox2.Text = member.LastName;
            textBox3.Text = member.CardNumber.ToString();
            dateTimePicker1.Value = member.StartDate;
            dateTimePicker2.Value = member.EndDate;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");

            var hasInsertedMember = 0;

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
                try
                {
                    Int32.Parse(textBox3.Text);

                    using (SqlCommand cmd = new SqlCommand(SQL_INSERT_NEW_MEMBER, sqlConn))
                    {
                        sqlConn.Open();

                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = textBox1.Text;
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = textBox2.Text;
                        cmd.Parameters.Add("@ScreenName", SqlDbType.NVarChar, 50).Value = textBox1.Text + ' ' + textBox2.Text;
                        cmd.Parameters.Add("@CardNumber", SqlDbType.Int).Value = Int32.Parse(textBox3.Text);
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dateTimePicker2.Value;

                        hasInsertedMember = cmd.ExecuteNonQuery();
                    }

                    if (hasInsertedMember == -1)
                    {
                        MessageBox.Show("Broj kartice " + textBox3.Text + " je zauzet.");
                    }
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Broj kartice mora biti broj!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cardNumber = Int32.Parse(textBox3.Text);

            SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");

            const string SQL_UPDATE_MEMBER = @"UPDATE memberstable
                                               SET FirstName = @FirstName,
                                                   LastName = @LastName,
	                                               ScreenName = @ScreenName,
	                                               StartDate = @StartDate,
	                                               EndDate = @EndDate
                                               WHERE
                                               CardNumber = @CardNumber";

            if (String.IsNullOrEmpty(textBox1.Text) ||
                String.IsNullOrEmpty(textBox2.Text) ||
                String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Popunite sva polja");
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand(SQL_UPDATE_MEMBER, sqlConn))
                {
                    sqlConn.Open();

                    cmd.Parameters.Add("@CardNumber", SqlDbType.Int).Value = Int32.Parse(textBox3.Text);

                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = textBox1.Text;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = textBox2.Text;
                    cmd.Parameters.Add("@ScreenName", SqlDbType.NVarChar, 50).Value = textBox1.Text + ' ' + textBox2.Text;
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dateTimePicker2.Value;

                    cmd.ExecuteNonQuery();
                }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var text = "";
            var extendForOneMonth = false;

            var numbOfDays = 0;

            try
            {
                numbOfDays = Int32.Parse(textBox4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Broj dana mora biti broj a ne slovo ili neki drugi karakter!");
            }

            if (String.IsNullOrWhiteSpace(textBox4.Text))
            {
                text = "mesec";
                extendForOneMonth = true;
            }
            else
            {
                text = textBox4.Text;
            }

            DialogResult dialog = MessageBox.Show("Da li želite da produžite članarinu za " + text + " dana", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (extendForOneMonth)
                {
                    dateTimePicker1.Value = dateTimePicker2.Value;
                    dateTimePicker2.Value = dateTimePicker2.Value.AddMonths(1);
                }
                else
                {
                    
                     dateTimePicker2.Value = dateTimePicker2.Value.AddDays(Int32.Parse(textBox4.Text));
                    
                }
            }
            else if (dialog == DialogResult.No)
            {

            }
        }
    }
}
