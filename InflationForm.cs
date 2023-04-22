using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LabWork3
{
    public partial class InflationForm : Form
    {
        private string fileName = string.Empty;
        private DataTableCollection tableCollection = null;
        public InflationForm()
        {
            InitializeComponent();
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;
                    Text = openFileDialog1.FileName;
                    OpenExcelFile(fileName);
                }
                else
                {
                    throw new Exception("Файд не выбран!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenExcelFile(string path)
        {
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
            DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration
            {
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            tableCollection = db.Tables;
            toolStripComboBox1.Items.Clear();
            foreach (DataTable table in tableCollection)
            {
                toolStripComboBox1.Items.Add(table.TableName);
            }
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = tableCollection[Convert.ToString(toolStripComboBox1.SelectedItem)];
            dataGridView1.DataSource = table;
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                double y = Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value);
                chart.Series[0].Points.AddXY(x, y);
            }
        }

        private void toolStripButtonCalc_Click(object sender, EventArgs e)
        {
            if (Price.Text != "" && dataGridView1 != null)
            {
                CalculationINF(dataGridView1);
                Price2023.Text = Convert.ToString(Convert.ToInt32(Price.Text) * Inf);
                Price2024.Text = Convert.ToString(Convert.ToInt32(Price.Text) * Inf * Inf);
                Price2025.Text = Convert.ToString(Convert.ToInt32(Price.Text) * Inf * Inf * Inf);
            }
        }

        private double Inf;
        internal void CalculationINF(DataGridView dataGridView)
        {
            double sum = 0;
            for (int i = 0; i < dataGridView.Rows.Count-1; i++)
            {
                sum += Convert.ToDouble(dataGridView.Rows[i].Cells[13].Value);
            }
            sum /= dataGridView.Rows.Count-1;
            Inf = sum / 100 + 1;
        }
    }
}
