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
    public partial class GalyaForm : Form
    {
        private GalyaPopulation var14;

        public GalyaForm()
        {
            InitializeComponent();
        }

        private void Var14Form_Load(object sender, EventArgs e)
        {

        }

        // Для вывода таблицы
        private void btnShowGrid_Click(object sender, EventArgs e)
        {
            // Create a new instance of Var14.
            var14 = new GalyaPopulation();

            // Open the file dialog.
            openFileDialog1.ShowDialog();

            // Get the path of the selected file.
            string path = openFileDialog1.FileName;

            // Read the Excel file.
            var14.ExcelFileReader(path, gridPopulation, chartPopulation);
        }
    }
}
