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
    public partial class LoginForm : MaterialSkin.Controls.MaterialForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            String connectionString = null;
            connectionString = "Data Source=KALPESH\\SQLEXPRESS;Initial Catalog=SampleDemoDB;Integrated Security=True;Pooling=False";
            SqlCommand cmd;
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            String sql;
            sql = "SELECT * FROM Login ";
            cmd = new SqlCommand(sql, cnn);

            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader["user_name"].ToString() == textBox1.Text && dataReader["password"].ToString() == textBox2.Text)
                {
                    Dashboard dboard = new Dashboard();
                    this.Hide();
                    dboard.Show();
                }
               // else
                {
                    //MessageBox.Show("Invalid Username or Password");
                }
            }
            
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                errorProvider1.SetError(textBox1, "This field is mandatory");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
                errorProvider2.SetError(textBox2, "This field is requiered");
        }
    }
}
