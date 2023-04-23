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
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net;

namespace LabWork3
{
    public partial class MedianSalary : Form
    {
        //Chart chart1 = new Chart();
        private string filename = string.Empty;
        //здесь храним листы из экселевского файла 
        private DataTableCollection table = null;
        public MedianSalary()
        {
            InitializeComponent();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

        }

        //метод, который отвечает за открытие и считывание таблицы
        //принимает путь
        private void excel(string path)
        {
            //в этом потоке открываем нужный файл
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
            //приводим значение, которое вернет метод этого класса, к интерфейсу
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
            //создаем базу данных
            DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                //присваиваем лямбда выражение
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    //свойство, которое отвечает за первую строчку таблицы (названия колонок)
                    UseHeaderRow = true,
                }
            });
            //присваиваем следующему полю все листы базы данных
            table = ds.Tables;
            //очищаем 
            toolStripComboBox1.Items.Clear();

            //переберем все названия таблиц из table, чтобы пользователь смог выбирать нужный
            foreach (DataTable t in table)
            {
                toolStripComboBox1.Items.Add(t.TableName);
            }
            //по умолчанию выбран первый элемент
            toolStripComboBox1.SelectedIndex = 0;
        }

        //открытие файла
        private void ВыборФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //блок обработки исключений
            try
            {
                //результат общения с пользователем
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    //путь к открытому файлу
                    filename = openFileDialog1.FileName;
                    //тайтл формы - путь к файлу
                    Text = filename;
                    //вызов  метода открытия базы данных
                    excel(filename);
                }
                else
                {
                    //ссылка на ошибку
                    throw new Exception("Файл не выбран");
                }
            }
            //вывод ошибки
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //после изменение индекса списка
            //отображение таблицы в поле формы
            DataTable Table = table[Convert.ToString(toolStripComboBox1.SelectedItem)];
            //присваиваем выбранную таблицу для отображения
            dataGridView1.DataSource = Table;
            //если выбрана 4 таблица, то график не строится
            //выводятся результаты вычислений
            if (toolStripComboBox1.SelectedIndex == 3)
            {
                //подсчет 
                richTextBox1.Text = "Вычисление процента роста зарплат\n";
                var k = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value);
                var g = Convert.ToDouble(dataGridView1.Rows[8].Cells[1].Value);
                var r = (g-k)/k*100;
                richTextBox1.Text += "Мужчины: " + Convert.ToString(Math.Round(r,3)) + "\n";

                k = Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value);
                g = Convert.ToInt32(dataGridView1.Rows[8].Cells[2].Value);
                r = (g - k) / k * 100;
                richTextBox1.Text += "Женщины: " + Convert.ToString(Math.Round(r,3));
            }
            //если выбрана иная таблица, то по ней выводится график
            else
            {
                chart1.Series[0].Points.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    double x = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                    double y = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    chart1.Series[0].Points.AddXY(x,y);
                }
            }
        }
    }
}
