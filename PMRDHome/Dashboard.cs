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
    public partial class Dashboard : MaterialSkin.Controls.MaterialForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            NK1 nk1obj = new NK1();
            this.Hide();
            nk1obj.Show();

            string conectionString = null;
            conectionString = "Data Source=KALPESH\\SQLEXPRESS;Initial Catalog=SampleDemoDB;Integrated Security=True;Pooling=False";
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(conectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT activity FROM Master";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                NK1 obj = new NK1();
               
                
            }

        }
    }
}
