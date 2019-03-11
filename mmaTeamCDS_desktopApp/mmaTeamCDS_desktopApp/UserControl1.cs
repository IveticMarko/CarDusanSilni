using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mmaTeamCDS_desktopApp
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            List<Member> listOfMembers = new List<Member>();

            SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");
            const string SQL_LOAD_ALL_MEMBERS = @"SELECT CardNumber, ScreenName, StartDate, EndDate
                                                  FROM memberstable";

            using (SqlCommand cmd = new SqlCommand(SQL_LOAD_ALL_MEMBERS, sqlConn))
            {
                sqlConn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Member member = new Member();
                            member.Broj_kartice = Int32.Parse((reader["CardNumber"].ToString()));
                            member.Član = reader["ScreenName"].ToString();
                            member.Datum_uplate = DateTime.Parse(reader["StartDate"].ToString()).ToString("dddd, dd MMMM yyyy");
                            member.Datum_isplate = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                            listOfMembers.Add(member);
                        }
                    }
                }
            }

            dataGridView1.DataSource = listOfMembers;

            //Dis doesn't work but try again.
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (Convert.ToInt32(row.Cells[0].Value) == 5)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.Red;
            //    }
            //}
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Member> listOfMembers = new List<Member>();

            SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");

            int cardNumber = 0;
            string text = "";

            var loadAllMembers = false;

            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    cardNumber = Int32.Parse(textBox1.Text.Replace(" ", ""));
                }
                catch (Exception)
                {
                    //do nothing;
                }
                text = '%' + textBox1.Text.Replace(" ", "") + '%';
            }
            else
            {
                loadAllMembers = true;
            }

            const string SQL_LOAD_ALL_MEMBERS = @"SELECT ScreenName, CardNumber, StartDate, EndDate
                                                  FROM memberstable";

            const string SQL_LOAD_MEMBERS = @"SELECT ScreenName, CardNumber, StartDate, EndDate
                                                  FROM memberstable
                                                  WHERE CardNumber = @CardNumber
	                                                    OR FirstName like @Text
	                                                    OR LastName like @Text";

            var sql = "";
            if (loadAllMembers)
            {
                sql = SQL_LOAD_ALL_MEMBERS;
            }
            else
            {
                sql = SQL_LOAD_MEMBERS;
            }

            using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
            {
                cmd.Parameters.Add("@CardNumber", SqlDbType.Int).Value = cardNumber;
                cmd.Parameters.Add("@Text", SqlDbType.NVarChar, 50).Value = text;

                sqlConn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Member member = new Member();
                            member.Broj_kartice = Int32.Parse((reader["CardNumber"].ToString()));
                            member.Član = reader["ScreenName"].ToString();
                            member.Datum_uplate = DateTime.Parse(reader["StartDate"].ToString()).ToString("dddd, dd MMMM yyyy");
                            member.Datum_isplate = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                            listOfMembers.Add(member);
                        }
                    }
                }
            }

            dataGridView1.DataSource = listOfMembers;
        }
    }
}
