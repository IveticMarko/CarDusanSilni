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
using System.Threading;

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
                                                  FROM memberstable
                                                  ORDER BY FirstName, LastName";

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
                            member.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                            listOfMembers.Add(member);
                        }
                    }
                }
            }

            dataGridView1.DataSource = listOfMembers;

            //Dis doesn't work but try again.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //row.Cells[0].ReadOnly = true;
                //if (Convert.ToInt32(row.Cells[0].Value) == 5)
                //{
                //    row.DefaultCellStyle.BackColor = Color.Red;
                //}
            }
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
                                                  FROM memberstable
                                                  ORDER BY FirstName, LastName";

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
                            member.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                            listOfMembers.Add(member);
                        }
                    }
                }
            }

            dataGridView1.DataSource = listOfMembers;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<Member> listOfMembers = new List<Member>();

            SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");
            const string SQL_LOAD_ALL_MEMBERS = @"SELECT CardNumber, ScreenName, StartDate, EndDate
                                                  FROM memberstable
                                                  ORDER BY FirstName, LastName";

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
                            member.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                            listOfMembers.Add(member);
                        }
                    }
                }
            }

            dataGridView1.DataSource = listOfMembers;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            List<Member> listOfMembers = new List<Member>();

            SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");
            const string SQL_LOAD_ALL_MEMBERS = @"SELECT CardNumber, ScreenName, StartDate, EndDate
                                                  FROM memberstable
                                                  ORDER BY CardNumber";

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
                            member.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                            listOfMembers.Add(member);
                        }
                    }
                }
            }

            dataGridView1.DataSource = listOfMembers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            List<Member> listOfMembers = new List<Member>();

            SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");
            const string SQL_LOAD_ALL_MEMBERS = @"SELECT CardNumber, ScreenName, StartDate, EndDate
                                                  FROM memberstable
                                                  ORDER BY FirstName, LastName";

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
                            member.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                            listOfMembers.Add(member);
                        }
                    }
                }
            }

            dataGridView1.DataSource = listOfMembers;
        }

        Bitmap bmp;

        private void button3_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                var cardNumber = selectedRow.Cells[0].Value;

                SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");

                const string SQL_LOAD_MEMBER = @"SELECT FirstName, LastName, CardNumber, ScreenName, StartDate, EndDate
                                                  FROM memberstable
                                                  WHERE CardNumber = @CardNumber";

                using (SqlCommand cmd = new SqlCommand(SQL_LOAD_MEMBER, sqlConn))
                {
                    RealMember member = new RealMember();

                    sqlConn.Open();

                    cmd.Parameters.Add("@CardNumber", SqlDbType.Int).Value = cardNumber;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            member = new RealMember();
                            member.CardNumber = Int32.Parse((reader["CardNumber"].ToString()));
                            member.FirstName = reader["FirstName"].ToString();
                            member.LastName = reader["LastName"].ToString();
                            member.ScreenName = reader["ScreenName"].ToString();
                            member.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                            member.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                        }
                    }

                    AddOrUpdateForm form = new AddOrUpdateForm(member);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        List<Member> listOfMembers = new List<Member>();
                        
                        const string SQL_LOAD_ALL_MEMBERS = @"SELECT CardNumber, ScreenName, StartDate, EndDate
                                                  FROM memberstable
                                                  ORDER BY FirstName, LastName";

                        cmd.CommandText = SQL_LOAD_ALL_MEMBERS;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Member updatedMember = new Member();
                                    updatedMember.Broj_kartice = Int32.Parse((reader["CardNumber"].ToString()));
                                    updatedMember.Član = reader["ScreenName"].ToString();
                                    updatedMember.Datum_uplate = DateTime.Parse(reader["StartDate"].ToString()).ToString("dddd, dd MMMM yyyy");
                                    updatedMember.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                                    listOfMembers.Add(updatedMember);
                                }
                            }
                        }

                        dataGridView1.DataSource = listOfMembers;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrUpdateForm mainForm = new AddOrUpdateForm();
            if (mainForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<Member> listOfMembers = new List<Member>();

                SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");
                const string SQL_LOAD_ALL_MEMBERS = @"SELECT CardNumber, ScreenName, StartDate, EndDate
                                                  FROM memberstable
                                                  ORDER BY FirstName, LastName";

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
                                member.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                                listOfMembers.Add(member);
                            }
                        }
                    }
                }

                dataGridView1.DataSource = listOfMembers;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Morate popuniti polje za broj dana.");
            }
            else
            {
                try
                {
                    Int32.Parse(textBox2.Text);
                }
                catch (Exception)
                {
                    return;
                }

                List<Member> listOfMembers = new List<Member>();

                SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");

                const string SQL_LOAD_MEMBERS_WHO_HAS_TO_PAY = @"SELECT CardNumber, ScreenName, StartDate, EndDate
                                                                 FROM memberstable
                                                                 WHERE EndDate BETWEEN GETUTCDATE() AND (GETUTCDATE() + @Days)";

                using (SqlCommand cmd = new SqlCommand(SQL_LOAD_MEMBERS_WHO_HAS_TO_PAY, sqlConn))
                {
                    sqlConn.Open();

                    cmd.Parameters.Add("@Days", SqlDbType.Int).Value = Int32.Parse(textBox2.Text);

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
                                member.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                                listOfMembers.Add(member);
                            }
                        }
                    }
                }

                dataGridView1.DataSource = listOfMembers;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                var cardNumber = selectedRow.Cells[0].Value;

                DialogResult dialog = MessageBox.Show("Da li želite da izbrišete člana?", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    List<Member> listOfMembers = new List<Member>();

                    SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");

                    const string SQL_DELETE_MEMBER = @"DELETE memberstable
                                                       WHERE CardNumber = @CardNumber";

                    const string SQL_LOAD_MEMBERS = @"SELECT CardNumber, ScreenName, StartDate, EndDate
                                                      FROM memberstable
                                                      ORDER BY FirstName, LastName";

                    using (SqlCommand cmd = new SqlCommand(SQL_DELETE_MEMBER, sqlConn))
                    {
                        sqlConn.Open();

                        cmd.Parameters.Add("@CardNumber", SqlDbType.Int).Value = cardNumber;

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = SQL_LOAD_MEMBERS;

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
                                    member.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                                    listOfMembers.Add(member);
                                }
                            }
                        }
                        dataGridView1.DataSource = listOfMembers;
                    }
                }
                else if (dialog == DialogResult.No)
                {

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("Da li želite da produžite članarinu za mesec dana?", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    List<Member> listOfMembers = new List<Member>();

                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    var cardNumber = selectedRow.Cells[0].Value;

                    SqlConnection sqlConn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CDS;Integrated Security=true");

                    const string SQL_UPDATE_DATES_OF_A_MEMBER = @"UPDATE memberstable
                                                          SET StartDate = EndDate, EndDate = DATEADD(month, 1, EndDate)
                                                          WHERE CardNumber = @CardNumber";

                    const string SQL_LOAD_MEMBERS = @"SELECT CardNumber, ScreenName, StartDate, EndDate
                                                  FROM memberstable
                                                  ORDER BY FirstName, LastName";

                    using (SqlCommand cmd = new SqlCommand(SQL_UPDATE_DATES_OF_A_MEMBER, sqlConn))
                    {
                        sqlConn.Open();

                        cmd.Parameters.Add("@CardNumber", SqlDbType.Int).Value = cardNumber;

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = SQL_LOAD_MEMBERS;

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
                                    member.Datum_isteka = DateTime.Parse(reader["EndDate"].ToString()).ToString("dddd, dd MMMM yyyy");

                                    listOfMembers.Add(member);
                                }
                            }
                        }

                        dataGridView1.DataSource = listOfMembers;
                    }
                }
                else if (dialog == DialogResult.No)
                {

                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DGV_To_Excel(dataGridView1);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = string.Format("{0}%", e.ProgressPercentage);
            progressBar1.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Thread.Sleep(100);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                return;
            }
            //using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls" })
            //{
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {

            //    }
            //}
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            backgroundWorker.RunWorkerAsync();

            //DGV_To_Excel(dataGridView1);
        }

        private void DGV_To_Excel(DataGridView dataGridView)
        {
            backgroundWorker.ReportProgress(2);

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            //app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            //for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
            //{
            //    worksheet.Cells[i, i + 1] = dataGridView.Columns[i - 1].HeaderText;
            //}

            int k = 1;
            worksheet.Cells[k, k + 1] = dataGridView.Columns[k - 1].HeaderText;
            worksheet.Cells[k, k + 2] = dataGridView.Columns[k].HeaderText;
            worksheet.Cells[k, k + 3] = dataGridView.Columns[k + 1].HeaderText;
            worksheet.Cells[k, k + 4] = dataGridView.Columns[k + 2].HeaderText;

            var index = 1;
            var process = dataGridView.Rows.Count;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                backgroundWorker.ReportProgress(index++ * 100 / process);
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 2] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 2] = "";
                    }
                }
            }
            //for (int i = 0; i < dataGridView.Rows.Count; i++)
            //{
            //    worksheet.Cells[i + 2, i] = dataGridView.Rows[i].HeaderCell.Value;
            //}

            app.Visible = true;
        }
    }
}
