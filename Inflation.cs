using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LabWork3
{
    internal class Inflation
    {

        internal double InfRate;
        // Функция подсчета среднего коэффициента инфляции
        internal void Calculation(DataGridView dataGridView)
        {
            double sum = 0;
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                sum += Convert.ToDouble(dataGridView.Rows[i].Cells[13].Value);
            }
            sum /= dataGridView.Rows.Count - 1;
            InfRate = sum / 100 + 1;
        }
    }
}
