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

namespace lr3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public bool IsDataOk(double left_limit, double right_limit, double step)
        {
            int flag=0;
            if (left_limit == right_limit)
            {
                MessageBox.Show("Левая граница не может быть равна правой.\n" +
                        "Измените одну из границ построения", caption: "Ошибка!",
                        buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                flag = 1;
            }

            if (step > Math.Abs(right_limit - left_limit))
            {
                MessageBox.Show("Шаг не может быть больше интервала между границами.\n" +
                    "Измените значение шага или расширьте границы.", caption: "Ошибка!",
                    buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                flag = 1;
            }
            if (step == 0)
            {
                MessageBox.Show("Шаг не может быть равен нулю.\n" +
                    "Измените значение шага.", caption: "Ошибка!",
                    buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                flag = 1;
            }
            if (left_limit > right_limit)
            {
                MessageBox.Show(text: "Левая граница не может быть больше правой.\n" +
                        "Измените границы построения.", caption: "Ошибка!",
                        buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                flag = 1;
            }
            if (flag == 1)
                return false;
            else
                return true;
        }

        public void CreateGraph()
        {  
            dataGridView1.Rows.Clear();
            chart1.ChartAreas[0].AxisX.Title = "x";
            chart1.ChartAreas[0].AxisY.Title = "y";
            var series = new Series();
            chart1.Series.Clear();

            var Series1 = "Положительная";
            var Series2 = "Отрицательная";

            chart1.Series.Add(Series1);
            chart1.Series.Add(Series2);
            chart1.Series[Series1].ChartType = SeriesChartType.Line;
            chart1.Series[Series2].ChartType = SeriesChartType.Line;

            double a_coef = Convert.ToDouble(Coef_a.Text);
            double c_coef = Convert.ToDouble(Coef_c.Text);
            double left_limit = Convert.ToDouble(LeftLimit.Text);
            double right_limit = Convert.ToDouble(RightLimit.Text);
            double step = Convert.ToDouble(Step.Text);

            IsDataOk(left_limit, right_limit, step);

            for (double x = left_limit; x < right_limit; x += step)
            {
                if (IsDataOk(left_limit, right_limit, step))
                {
                    double y1 = Functions.PositiveFunction(x, a_coef, c_coef);
                    chart1.Series[Series1].Points.AddXY(x, y1); // Добавили точку для первого графика
                    if (!double.IsNaN(y1))
                    {
                        dataGridView1.Rows.Add(x, y1);
                    }
                    double y2 = Functions.NegativeFunction(x, a_coef, c_coef);
                    chart1.Series[Series2].Points.AddXY(x, y2); // Добавили точку для второго графика*/
                    if (!double.IsNaN(y2))
                    {
                        dataGridView1.Rows.Add(x, y2);
                    }
                }
                else break;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateGraph();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(text: "Автор программы: Голова Елена, 474\n" +
              "Назначение программы - построение графика функции:\n" +
              "Овал Кассини.\n\n",
              caption: "О программе",
              buttons: MessageBoxButtons.OK,
              icon: MessageBoxIcon.Information);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Png files (*.png)|*.png|All files(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                chart1.SaveImage(save.FileName, ChartImageFormat.Png);
            }
            MessageBox.Show(text: "График сохранен успешно", caption: "Информация", buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
        }

        private void SaveXYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "xlsx files (*.xlsx)|*.xlsx|All files(*.*)|*.*";
            string file_name = string.Empty;

            Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelapp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;

            if (save.ShowDialog() == DialogResult.OK)
            {
                file_name = save.FileName;
                try
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            worksheet.Rows[i + 1].Columns[j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                        }
                    }
                    excelapp.AlertBeforeOverwriting = false;
                    workbook.SaveAs(file_name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    save.Dispose();
                    excelapp.Quit();

                    MessageBox.Show(text: "Данные сохранены успешно!", caption: "Информация",
                        buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show(text: "При сохранении данных произошла ошибка!", caption: "Ошибка! :(",
                        buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
            }
        }
    }
}
