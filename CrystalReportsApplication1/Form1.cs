using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CrystalReportsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var culture = new CultureInfo("pt-BR", false);
            string d = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", culture).ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine(d);
            //DateTime d2 = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            SqlConnection con = new SqlConnection("Data Source=192.168.16.150;Initial Catalog=ContosoUniversity1;Persist Security Info=True;User ID=sa;Password=SenhaSecreta@123");
            SqlCommand command = new SqlCommand("select * from Students where EnrollmentDate >= '"+d+"'", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataSet s = new DataSet();
            sd.Fill(s);

            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(s.Tables["table"]);
            crystalReportViewer1.ReportSource = cr;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
