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

namespace LabWork3
{
    public partial class Var14Form : Form
    {
        private Var14 var14;

        public Var14Form()
        {
            InitializeComponent();
        }

        private void Var14Form_Load(object sender, EventArgs e)
        {

        }

        // Для вывода графика
        private void btnShowChart_Click(object sender, EventArgs e)
        {
            /*            // Get the data from the Excel table.
                        string excelFilePath = @"D:\programming-technologies\population_Data.xlsx";
                        string worksheetName = "Subjects";
                        string range = "B2:D8";

                        // Set the chart's data source.
                        chartPopulation.DataSource = excelFilePath + "!" + worksheetName + "!" + range;*/

            var14 = new Var14();

            var14.ChartReader(chartPopulation);
        }

        // Для вывода таблицы
        private void btnShowGrid_Click(object sender, EventArgs e)
        {
            // Create a new instance of Var14.
            var14 = new Var14();

            // Open the file dialog.
            openFileDialog1.ShowDialog();

            // Get the path of the selected file.
            string path = openFileDialog1.FileName;

            // Read the Excel file.
            var14.ExcelFileReader(path, gridPopulation);
        }
    }
}
