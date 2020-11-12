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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=WINDOWS-R1VRDR1;Initial Catalog=theJoeDb;User ID=zoidberg;Password=joeisgreat";
            conn = new SqlConnection(connetionString);
            conn.Open();
            //MessageBox.Show("Connection Open  !");

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            // sql we want to run
            sql = "select * from testTable2";

            // setup the command, using the sql above and the connection
            command = new SqlCommand(sql, conn);

            dataReader = command.ExecuteReader();

            // while we have data, go get it 
            // the table has 2 columns, "idNumber" and "someText", these are GetValue(0) and GetValue(1) respectively.
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }

            MessageBox.Show(Output);
            conn.Close();
        }
    }
}
