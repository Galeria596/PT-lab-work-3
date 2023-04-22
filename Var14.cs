using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LabWork3
{
    public class GalyaPopulation
    {
        // Считывает данные из Excel файла и выводит их в таблицу и график.
        public void ExcelFileReader(string excelFilePath, DataGridView dataGridView, Chart chartControl)
        {
            try
            {
                // Открытие Excel файла.
                using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Запись данных из таблиц в переменную.
                    var tableData = reader.AsDataSet();

                    // Добавление таблицы с полученными данными в форму.
                    dataGridView.DataSource = tableData.Tables[0];

                    // Создание стиля для клеточек-хедеров
                    DataGridViewCellStyle dataGridViewHeadersStyle = new DataGridViewCellStyle();
                    dataGridViewHeadersStyle.Font = new Font("Segoe UI Semibold", 11);
                    dataGridViewHeadersStyle.BackColor = Color.Gainsboro;

                    // Установка стиля для хедеров
                    dataGridView.Columns[0].DefaultCellStyle = dataGridViewHeadersStyle;
                    dataGridView.Rows[0].DefaultCellStyle = dataGridViewHeadersStyle;

                    // Вызов метода для создания графика.
                    ExcelFileToChart(chartControl, tableData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading Excel file: " + ex.Message);
            }
        }

        public void ExcelFileToChart(Chart chartControl, DataSet tableData)
        {
            // Вызов функции для добавления заголовка.
            AddChartTitle(chartControl);

            // Создание графика.
            for (int i = 1; i < tableData.Tables[0].Rows.Count; i++)
            {
                // Считывает имена субъектов из первой колонки.
                string seriesName = tableData.Tables[0].Rows[i][0].ToString();

                // Создание новой серии с названием субъекта.
                var series = new Series(seriesName);

                // Устанавливает тип графика.
                series.ChartType = SeriesChartType.RangeColumn;

                // Проход по всем столбцам строки.
                for (int j = 1; j < tableData.Tables[0].Columns.Count; j++)
                {
                    // Добавляет значение ячейки серии графика, где X - год, Y - популяция.
                    series.Points.AddXY(2023 - j, tableData.Tables[0].Rows[i][j]);
                }

                // Добавляет серию в график.
                chartControl.Series.Add(series);

                // Установка ширины и цвета обводки
                chartControl.Series[seriesName].BorderWidth = 1;
                chartControl.Series[seriesName].BorderColor = Color.Black;
            }
        }

        // Добавляет заголовок для графика.
        public void AddChartTitle(Chart chartControl)
        {
            // Установка параметров
            Title title = new Title();
            title.Alignment = ContentAlignment.TopLeft;
            title.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            title.ForeColor = Color.DimGray;
            title.Name = "Title1";
            title.Text = "Population data by subjects";

            // Добавление
            chartControl.Titles.Add(title);
        }

        // Метод для проверки файла на расширение excel
        public void ExcelFileCheck(OpenFileDialog openExcelFileDialog, DataGridView dataGridView, Chart chartControl)
        {
            // Фильтр для выбора файла
            openExcelFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

            // Проверка на excel файлы
            if (openExcelFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Если выбран excel файл
                if (Path.GetExtension(openExcelFileDialog.FileName).Equals(".xlsx"))
                {
                    // Получение пути к выбранному файлу.
                    string path = openExcelFileDialog.FileName;

                    // Вызов метода для чтения файла и вывода данных из него в таблицу и график.
                    ExcelFileReader(path, dataGridView, chartControl);
                }
                else
                {
                    // Если выбран не excel файл
                    MessageBox.Show("Please select an Excel file.");
                }
            }
        }
    }
}
