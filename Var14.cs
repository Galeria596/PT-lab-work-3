using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LabWork3
{
    public class GalyaPopulation
    {
        // Считывает данные из Excel файла и выводит их в таблицу и график.
        public void DisplayExcelData(string excelFilePath, DataGridView dataGridView, Chart chartControl)
        {
            try
            {
                // Открытие Excel файла.
                using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Запись данных из таблиц.
                    var tableData = reader.AsDataSet();

                    // Добавление таблицы с полученными данными в форму.
                    dataGridView.DataSource = tableData.Tables[0];

                    // Установка стиля для клеточек-хедеров.
                    DataGridViewCellStyle dataGridViewHeadersStyle = new DataGridViewCellStyle();
                    dataGridViewHeadersStyle.Font = new Font("Segoe UI Semibold", 10);
                    dataGridViewHeadersStyle.BackColor = Color.Gainsboro;
                    dataGridView.Columns[0].DefaultCellStyle = dataGridViewHeadersStyle;
                    dataGridView.Rows[0].DefaultCellStyle = dataGridViewHeadersStyle;

                    // Создание графика.
                    ExcelFileToChart(chartControl, tableData);

                    // Нахождение субъекта с самым большим изменением населения.
                    FindMaxPopulationChange(tableData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading Excel file: " + ex.Message);
            }
        }

        // Метод для нахождения субъекта с самым большим изменением населения за 15 лет.
        void FindMaxPopulationChange (DataSet tableData)
        {
            // Получение индекса последней колонки.
            int lastColumnIndex = tableData.Tables[0].Columns.Count - 1;

            // Создание списка со значением изменения численности каждого субъекта.
            List<int> populatioтСhange = new List<int>();

            // Проходится по всем субъектам и считает изменения для каждого из них.
            for (int i = 1; i < tableData.Tables[0].Rows.Count; i++)
            {
                // Получение значения численности в начале.
                string firstRowToString = tableData.Tables[0].Rows[i][1].ToString();
                int.TryParse(firstRowToString, out int startPopulation);

                // Получение значения численности в конце.
                string lastRowToString = tableData.Tables[0].Rows[i][lastColumnIndex].ToString();
                int.TryParse(lastRowToString, out int endPopulation);

                // Добавляет значение в список.
                populatioтСhange.Add(endPopulation - startPopulation);
            }

            // Нахождение максимального изменения и его индекса.
            int maxChange = populatioтСhange.Max();
            int maxChangeIndex = populatioтСhange.IndexOf(maxChange);

            // Название субъекта с самым большим значением.
            string maxChangeSubject = tableData.Tables[0].Rows[maxChangeIndex + 1][0].ToString();

            // Вывод значения на экран.
            MessageBox.Show($"Subject with largest population change in the last 15 years is {maxChangeSubject}.\nChange = {maxChange} people.");
        }

        // Метод для создания графика.
        public void ExcelFileToChart(Chart chartControl, DataSet tableData)
        {
            // Добавление заголовка для графика.
            AddChartTitle(chartControl);

            // Проходится по строкам таблицы.
            for (int i = 1; i < tableData.Tables[0].Rows.Count; i++)
            {
                // Считывает имена субъектов из первой колонки.
                string seriesName = tableData.Tables[0].Rows[i][0].ToString();

                // Создание новой серии с названием субъекта.
                var series = new Series(seriesName);

                // Устанавливает тип графика для серии.
                series.ChartType = SeriesChartType.RangeColumn;

                // Проходится по столбцам строки.
                for (int j = 1; j < tableData.Tables[0].Columns.Count; j++)
                {
                    // Добавляет значение ячейки к серии, где X - год, Y - популяция.
                    series.Points.AddXY(2023 - j, tableData.Tables[0].Rows[i][j]);
                }

                // Добавляет серию в график.
                chartControl.Series.Add(series);

                // Установка ширины и цвета обводки.
                chartControl.Series[seriesName].BorderWidth = 1;
                chartControl.Series[seriesName].BorderColor = Color.Black;
            }
        }

        // Метод для добавления заголовока графика.
        public void AddChartTitle(Chart chartControl)
        {
            Title title = new Title
            {
                Name = "Title1",
                Text = "Population data by subjects",
                Alignment = ContentAlignment.TopLeft,
                Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold),
                ForeColor = Color.DimGray
            };

            chartControl.Titles.Add(title);
        }

        // Метод для проверки файла на расширение excel.
        public void LoadExcelFile(DataGridView dataGridView, Chart chartControl)
        {
            using (var excelFileDialog = new OpenFileDialog())
            {
                // Фильтр для excel файлов.
                excelFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                // Показывает окно выбора файла и получает имя выбранного файла.
                if (excelFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Если выбран excel файл
                    if (Path.GetExtension(excelFileDialog.FileName).Equals(".xlsx"))
                    {
                        // Получение пути к выбранному файлу.
                        string path = excelFileDialog.FileName;

                        // Вызов метода для чтения файла и вывода данных из него в таблицу и график.
                        DisplayExcelData(path, dataGridView, chartControl);
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
}
