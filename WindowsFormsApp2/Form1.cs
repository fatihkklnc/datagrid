using Intuit.Ipp.Data;
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

namespace WindowsFormsApp2
{

    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            

        }
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        
        

       
        private void button1_Click(object sender, EventArgs e)
        {
            
            

            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];

            if(ch1.Value == null)
                ch1.Value = false;
            
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    checkBox1.Checked = false;
                    if (dataGridView2.Rows.Count > 0)
                        for(int i=0;i<dataGridView2.Rows.Count;i++)
                            if(dataGridView2.Rows[i].Cells[1].Value == dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value)
                            dataGridView2.Rows.RemoveAt(dataGridView2.Rows[i].Index);
                    break;
                case "False":
                    if (e.RowIndex != -1)
                    {
                        ch1.Value = true;
                        tablo.Rows.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value, dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
                    }
                        break;
            }
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tablo.Columns.Add("ADI", typeof(string));
            tablo.Columns.Add("NUMARASI", typeof(string));
            dataGridView2.DataSource = tablo;
            tablo2.Columns.Add("ADI", typeof(string));
            tablo2.Columns.Add("NUMARASI", typeof(string));
            tablo2.Rows.Add("FAtih", "05301505815");
            tablo2.Rows.Add("FAtih2", "05301505815");
            dataGridView1.DataSource = tablo2;

        }

        
        private void checkBox1_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    ch1 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];


                    if (Convert.ToBoolean(ch1.Value) == false)
                    {
                        tablo.Rows.Add(dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[2].Value);
                        ch1.Value = true;
                    }

                }

            }
            int dataCount = dataGridView2.Rows.Count;
            if (checkBox1.Checked == false)
            {
                for (int a = 0; a < dataCount; a++)
                {

                    ch1 = (DataGridViewCheckBoxCell)dataGridView1.Rows[a].Cells[0];
                    ch1.Value = false;

                    dataGridView2.Rows.RemoveAt(dataGridView2.Rows[0].Index);


                }


            }
        }
    }
}
