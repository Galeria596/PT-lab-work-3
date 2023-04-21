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
    public class GalyaPopulation
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
        public void ExcelFileReader(string path, DataGridView dataGrid, Chart chart)
        {

            // Open the Excel file.
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                // Создание ридера для чтения Excel файла
                var reader = ExcelReaderFactory.CreateReader(stream);

                // Запись данных из таблиц в переменную
                var result = reader.AsDataSet();

                // Добавление первой таблицы в качестве источника для DataGrig
                dataGrid.DataSource = result.Tables[0];

                //var cellValue = result.Tables[0].Rows[1][0].ToString();
                for (int i = 1; i < result.Tables[0].Rows.Count; i++)
                {
                    string cellName = result.Tables[0].Rows[i][0].ToString();

                    // Создание новой серии графика с именем субъекта
                    var series = new Series(cellName);

                    for (int j = 1; j < result.Tables[0].Columns.Count; j++)
                    {
                        series.Points.AddXY(2023-j, result.Tables[0].Rows[i][j]);
                        Console.WriteLine(series.Points[j-1]);
                    }
                    chart.Series.Add(series);
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                }
                /*foreach (DataRow tableRow in result.Tables[0].Rows)
                {
                    // Проверка на 1 элемент, который содержит название колонки
                    if (tableRow.ToString() != "Subject")
                    {
                        // Создание новой серии графика с именем субъекта
                        var series = new Series(tableRow.ToString());

                        var cols = result.Tables[0].Columns;

                        //int subjectPopulationData = result.Tables[0].Columns;

                        //series.Points.AddXY(tableColumns.ToString());

                        //chart.Series.Add(series);
                    }


                }*/

                /*foreach (DataColumn tableColumns in result.Tables[0].Columns)
                {
                    // Проверка на 1 элемент, который содержит название колонки
                    if (tableColumns.ToString() != "Subject")
                    {
                        // Создание новой серии графика с именем субъекта
                        var series = new Series(tableColumns. *//*.ToString()*//*);

                        var cols = result.Tables[0].Columns;

                        //int subjectPopulationData = result.Tables[0].Columns;

                        //series.Points.AddXY(tableColumns.ToString());

                        //chart.Series.Add(series);
                    }


                }*/

            }
        }



        /*
        Выводит график по данным из таблицы Excel.
        Еще не готов.
        */
        public void ChartReader(Chart chart, String cellName, int collumnsCount)
        {
            // Создание новой серии графика с именем субъекта
            var seriesn = new Series(cellName);

            for (int i = 1; i < collumnsCount; i++)
            {
                // seriesn.Points.AddXY()
            }


            //chart.Series.Add(series);



            // create a new series and set its name
            /*var series1 = new Series("Moscow");

              // add data points to the series
              series1.Points.AddXY(1, 2);
              series1.Points.AddXY(2, 3);
              series1.Points.AddXY(3, 4);

              // set the chart type for the series
              series1.ChartType = SeriesChartType.Line;

              // add the series to the chart
              chart.Series.Add(series1);*/


        }
    }
}
