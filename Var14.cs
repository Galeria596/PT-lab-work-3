using ExcelDataReader;
using System;
using System.Collections.Generic;
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
    // Класс с основыми методами для формы
    public class Var14
    {
        /*        public void meth()
                {
                    string populationTablePath = @"D:\programming-technologies\cheats_prices 1.xlsx";

                    using (var stream = File.Open(populationTablePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {

                            // 2. Use the AsDataSet extension method
                            var result = reader.AsDataSet();

                            // The result of each spreadsheet is in result.Tables
                            DataTable dt = result.Tables[0];

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                Console.WriteLine();
                                for (int y = 0; y < dt.Columns.Count; y++)
                                {
                                    Console.Write($"{dt.Rows[i][y].ToString()}\t");
                                }
                                Console.WriteLine();
                            }
                            //MessageBox.Show(dt.Rows[1][2].ToString());
                            //Console.WriteLine(dt.Rows[0][0]);
                        }
                    }
                }*/

        // Считывает данные из Excel файла и выводит в DataGridView
        public void ExcelFileReader(string path, DataGridView dataGrid)
        {
            // Open the Excel file.
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                // Создание ридера для чтения Excel файла
                var reader = ExcelReaderFactory.CreateReader(stream);

                // Запись данных их таблицы в переменную
                var result = reader.AsDataSet();

                // Получение всех таблиц из файла
                var tables = result.Tables.Cast<DataTable>();

                // Добавление таблиц в DataGrid
                foreach (var table in tables)
                {
                    dataGrid.DataSource = table;
                }


                // SIMPLIFY
                /*foreach (DataRow ds in result.Tables[0].Rows)
                {
                    if (ds[0].ToString() != "Subject")
                    {
                        var series = new Series(ds[0].ToString());


                        Console.WriteLine(ds[0]);
                    }
                }*/

            }
        }



        /*
        Выводит график по данным из таблицы Excel.
        Еще не готов.
        */
        public void ChartReader(/*string excelFilePath, string worksheetName, string range, */Chart chart)
        {
            // create a new series and set its name
            var series1 = new Series("Moscow");

            // add data points to the series
            series1.Points.AddXY(1, 2);
            series1.Points.AddXY(2, 3);
            series1.Points.AddXY(3, 4);

            // set the chart type for the series
            series1.ChartType = SeriesChartType.Line;

            // add the series to the chart
            chart.Series.Add(series1);


        }
    }
}
