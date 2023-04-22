using System;
using System.Windows.Forms;

namespace LabWork3
{
    public partial class GalyaForm : Form
    {
        // Объявление класса с методами для формы.
        private GalyaPopulation var14Functions;

        public GalyaForm() => InitializeComponent();

        private void Var14Form_Load(object sender, EventArgs e) { }

        // Кнопка для вывода таблицы и графика.
        private void btnShowGrid_Click(object sender, EventArgs e)
        {
            // Создание нового экземпляра класса.
            var14Functions = new GalyaPopulation();

            // Проверка расширения файла
            var14Functions.ExcelFileCheck(openFileDialog1, gridPopulation, chartPopulation1);

        }
    }
}
