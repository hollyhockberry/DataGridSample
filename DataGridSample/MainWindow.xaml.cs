using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (DataContext is System.ComponentModel.INotifyPropertyChanged vm)
            {
                vm.PropertyChanged += (_, e) =>
                {
                    if (e.PropertyName?.Equals("DataTable") != true)
                    {
                        return;
                    }
                    if (VisualTreeHelper.GetChildrenCount(DataGrid) <= 0)
                    {
                        return;
                    }
                    if (VisualTreeHelper.GetChild(DataGrid, 0) is Decorator border)
                    {
                        var scrollViewer = border.Child as ScrollViewer;
                        scrollViewer?.ScrollToHorizontalOffset(scrollViewer!.HorizontalOffset);
                    }
                };
            }
        }
    }
}
