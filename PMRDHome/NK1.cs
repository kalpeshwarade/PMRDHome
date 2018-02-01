using MaterialSkin.Controls;
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

namespace PMRDHome
{
    public partial class NK1 : MaterialSkin.Controls.MaterialForm
    {

        private const string ConnectionString = "Data Source=KALPESH\\SQLEXPRESS;Initial Catalog=SampleDemoDB;Integrated Security=True;Pooling=False";


        public NK1()
        {
            InitializeComponent();
            this.BindGrid();
        }

        private void NK1_Load(object sender, EventArgs e)
        {

        }

        public void BindGrid()
        {
            /*
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                
                string sql = "SELECT * FROM Master";
                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            } */

            //Add Checkbox
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
         
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            //database connection
            string connectionString = "Data Source=KALPESH\\SQLEXPRESS;Initial Catalog=SampleDemoDB;Integrated Security=True;Pooling=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            int i = 0;
            string sql = "SELECT activity from Master";
            string sql1 = "SEELCT time FROM Master";
            string sql2 = "SELECT frequency FROM Master";
            sqlConnection = new SqlConnection(connectionString);



            //adding label and button
            MaterialLabel label = new MaterialLabel();
            int count = panel1.Controls.OfType<MaterialLabel>().ToList().Count;
            label.Location = new Point(10, (25 * count) + 2);
            label.Size = new Size(60, 20);
            label.Name = "label_" + (count + 1);
            label.Text = "Activity" + (count + 1);
            panel1.Controls.Add(label);

            // TextBox textBox = new TextBox();
            ComboBox comboBox = new ComboBox();
            count = panel1.Controls.OfType<ComboBox>().ToList().Count;
            comboBox.Location = new Point(100, (25 * count) + 2);
            comboBox.Size = new Size(80, 20);
            // textBox.Name = "label_" + (count + 1);
            // textBox.TextChanged  += new System.EventHandler(this.TextChanged);
            panel1.Controls.Add(comboBox);
            try
            {
                sqlConnection.Open();
                cmd = new SqlCommand(sql, sqlConnection);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                adapter.Dispose();
                cmd.Dispose();
                sqlConnection.Close();
                comboBox.DataSource = ds.Tables[0];
                comboBox.ValueMember = "activity";
            }
            catch
            {
                MessageBox.Show("Can't connected to combobox");
            }

        }
        

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
