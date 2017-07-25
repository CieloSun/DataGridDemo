using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DataGridTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataTable dataTable;
        public MainWindow()
        {
            InitializeComponent();
            //通过DataTable自动生成DataGridView
            dataTable = new DataTable("test");
            for (int i = 0; i < 3; ++i)
            {
                dataTable.Columns.Add();
            }
            for(int i = 0; i < 2; ++i)
            {
                dataTable.Rows.Add(dataTable.NewRow());
            }
            dataTable.Rows[0][0] = 0;
            dataTable.Rows[0][1] = 999;
            dataTable.Rows[0][2] = -1;
            dataTable.Rows[1][0] = 1;
            dataTable.Rows[1][1] = 2;

            dataGrid.ItemsSource = dataTable.DefaultView;
            dataGrid.HeadersVisibility = DataGridHeadersVisibility.None;
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //每行背景色设置
            int rowIndex = e.Row.GetIndex();
            if (rowIndex % 2 == 0)
            {
                e.Row.Background = Brushes.AliceBlue;
            }
            //根据单元格内容设置前景色
            if (rowIndex > 0)
            {
                for(int i = 0; i < dataTable.Columns.Count; ++i)
                {
                    string value = (dataTable.Rows[rowIndex - 1][i].ToString());
                    if (value.Length != 0)
                    {
                        (dataGrid.Columns[i].GetCellContent(dataGrid.Items[rowIndex - 1]) as TextBlock).Foreground = (int.Parse(value)>0) ? Brushes.Green : Brushes.Red;
                    }
                }
            }
        }
    }
}
