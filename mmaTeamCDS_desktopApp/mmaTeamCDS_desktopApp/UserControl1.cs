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
            const string SQL_LOAD_ALL_MEMBERS = @"SELECT CardNumber, ScreenName FROM memberstable";

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

                            listOfMembers.Add(member);
                        }
                    }
                }
            }

            dataGridView1.DataSource = listOfMembers;
        }
    }
}
