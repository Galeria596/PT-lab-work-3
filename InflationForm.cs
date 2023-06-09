﻿using ExcelDataReader;
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
        // Определение переменных класса
        private string fileName = string.Empty;
        private DataTableCollection tableCollection = null;
        private Inflation Inf = new Inflation();
        public InflationForm()
        {
            InitializeComponent();
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Отображение диалогового окна выбора файла
                DialogResult res = openFileDialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    // Запоминание имени файла
                    fileName = openFileDialog.FileName;
                    // Вызов метода для чтения данных из файла Excel
                    OpenExcelFile(fileName);
                }
                else
                {
                    // Вывод ошибки, если файл не выбран
                    throw new Exception("Файл не выбран!");
                }
            }
            catch (Exception ex)
            {
                // Вывод ошибки в диалоговом окне
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Метод для чтения данных из файла Excel
        private void OpenExcelFile(string path)
        {
            // Открытие потока для чтения выбранного файла Excel
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
            // Создание объекта для чтения данных из файла Excel
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
            // Чтение данных из файла Excel и преобразование их в объект DataSet
            DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration
            {
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            // Запоминание всех таблиц из объекта DataSet
            tableCollection = db.Tables;
            // Очистка комбобокса
            toolStripComboBox.Items.Clear();
            // Добавление всех таблиц в комбобокс
            foreach (DataTable table in tableCollection)
            {
                toolStripComboBox.Items.Add(table.TableName);
            }
            // Установка индекса комбобокса на первую таблицу
            toolStripComboBox.SelectedIndex = 0;
        }
        // Метод выбора таблиц
        private void toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получение выбранной таблицы
            DataTable table = tableCollection[Convert.ToString(toolStripComboBox.SelectedItem)];
            // Отображение данных таблицы в DataGridView
            dataGridView.DataSource = table;
        }
        // Добавление точек на график
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Проходимся по всем строкам таблицы, кроме последней (которая содержит пустые ячейки)
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    // Получаем значения из ячеек с номером 0 (столбец X) и 13 (столбец Y)
                    double x = Convert.ToDouble(dataGridView.Rows[i].Cells[0].Value);
                    double y = Convert.ToDouble(dataGridView.Rows[i].Cells[13].Value);
                    // Добавляем точку на график с полученными координатами
                    chart.Series[0].Points.AddXY(x, y);
                }
            }
            catch (Exception ex)
            {
                // Если произошла ошибка, выводим сообщение об ошибке
                MessageBox.Show(ex.Message,"Кажется вы выбрали не тот файл!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Метод расчета цен на будущие годы
        private void toolStripButtonCalc_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка, что поле ввода цены не пустое и была выбрана первая таблица
                if (Price.Text != "" && dataGridView != null && toolStripComboBox.SelectedIndex == 0)
                {
                    // Вызов метода расчета инфляции на основе выбранной таблицы
                    Inf.Calculation(dataGridView);
                    // Вычисление цен на будущие годы на основе расчетов инфляции
                    Price2023.Text = Convert.ToString(Math.Round(Convert.ToDouble(Price.Text) * Inf.InfRate, 2));
                    Price2024.Text = Convert.ToString(Math.Round(Convert.ToDouble(Price.Text) * Inf.InfRate * Inf.InfRate, 2));
                    Price2025.Text = Convert.ToString(Math.Round(Convert.ToDouble(Price.Text) * Inf.InfRate * Inf.InfRate * Inf.InfRate, 2));
                }
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке, если введенное значение не является числом с запятой
                MessageBox.Show(ex.Message, "Поле принимает только тип double с запятой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                    // Очистка поля ввода цены
                    Price.Clear();
            }
        }

    }
}
