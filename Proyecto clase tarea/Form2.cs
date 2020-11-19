using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_clase_tarea
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (openFileDialog1.ShowDialog().Equals(CancelButton)==false) {
                textBox1.Text= openFileDialog1.FileName;
            Spire.Xls.Workbook wb = new Spire.Xls.Workbook();
            wb.LoadFromFile(textBox1.Text);
            Spire.Xls.Worksheet ws = wb.Worksheets[0];
            dataGridView1.DataSource = ws.ExportDataTable(); }
            else
            {
               
            } }catch(Exception ex)
            {
                MessageBox.Show("Cagaste en algo chavon");
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                
                northwindDataSetTableAdapters.QueriesTableAdapter n = new northwindDataSetTableAdapters.QueriesTableAdapter();
                for(int i=0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    n.insertarterritorios(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                }
                this.territoriesTableAdapter.Fill(this.northwindDataSet.Territories);

            } catch(Exception ex) { MessageBox.Show("Cagaste en algo chavon"); }
            
            
        }

        private void territoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.territoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Territories' table. You can move, or remove it, as needed.
            this.territoriesTableAdapter.Fill(this.northwindDataSet.Territories);

        }
    }
}
