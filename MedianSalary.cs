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
        private string filename = string.Empty;
        //здесь храним листы из экселевского файла 
        private DataTableCollection table = null;
        string[] list = new string[50];
        public MedianSalary()
        {
            InitializeComponent();
        }
        //private int ExportExcel()
        //{
        //    Excel.Application ObjWorkExcel = new Excel.Application();
        //    Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(openFileDialog1.FileName);
        //    Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1-й лист
        //    var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку
        //                                                                                        // размеры базы
        //    int lastColumn = (int)lastCell.Column;
        //    int lastRow = (int)lastCell.Row;
        //    // Перенос в промежуточный массив класса Form1: string[,] list = new string[50, 5]; 
        //    for (int j = 0; j < 5; j++) //по всем колонкам
        //        for (int i = 0; i < lastRow; i++) // по всем строкам
        //            list[i, j] = ObjWorkSheet.Cells[i + 1, j + 1].Text.ToString(); //считываем данные
        //    ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
        //    ObjWorkExcel.Quit(); // выйти из Excel
        //    GC.Collect(); // убрать за собой
        //    return lastRow;
        //}

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
            //toolStripComboBox1.SelectedIndex = 0;

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////блок обработки исключений
            //try
            //{
            //    //результат общения с пользователем
            //    DialogResult res = openFileDialog1.ShowDialog();
            //    if (res == DialogResult.OK)
            //    {
            //        //путь к открытому файлу
            //        filename = openFileDialog1.FileName;
            //        //тайтл формы - путь к файлу
            //        Text = filename;
            //        //вызов  метода открытия базы данных
            //        excel(filename);
            //    }
            //    else
            //    {
            //        //ссылка на ошибку
            //        throw new Exception("Файл не выбран");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //после изменение индекса списка
            //отображение таблицы в поле формы
            DataTable Table = table[Convert.ToString(toolStripComboBox1.SelectedItem)];
            //присваиваем выбранную таблицу для отображения
            dataGridView1.DataSource = Table;
        }

        private void построитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application ObjWorkExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(openFileDialog1.FileName);
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1-й лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку
                                                                                                // размеры базы
            int lastColumn = (int)lastCell.Column;
            int lastRow = (int)lastCell.Row;
            // Перенос в промежуточный массив класса Form1: string[,] list = new string[50, 5]; 
            //for (int j = 0; j < 5; j++) //по всем колонкам
            //    for (int i = 0; i < lastRow; i++) // по всем строкам
            //        list[i, j] = ObjWorkSheet.Cells[i + 1, j + 1].Text.ToString(); //считываем данные
            Chart myChart = new Chart();
            myChart.Parent = this;
            myChart.ChartAreas.Add(new ChartArea("Data"));
            Series mySeriesOfPoint = new Series("Line");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Data";
            int k = 2008;
            for (int i = 1; i < lastRow; i++)
            { //по всем колонкам
                
                // по всем строкам
                list[i] = ObjWorkSheet.Cells[i+1, 2].Text.ToString();
                mySeriesOfPoint.Points.AddXY(k,list[i]);
                k += 1;
            }
            
            myChart.Series.Add(mySeriesOfPoint);
            ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            ObjWorkExcel.Quit(); // выйти из Excel
            
            GC.Collect(); // убрать за собой
            

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
