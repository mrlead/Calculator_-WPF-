using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            this.MatrixSize = Enumerable.Range(2, 9).ToArray();
            this.DataContext = this;
        }

        public IList MatrixSize { get; private set; }
        public object Matrix { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var size = (int)e.AddedItems[0];
            this.UpdateMatrix(size);
        }

        void UpdateMatrix(int size)
        {
            var dt = new DataTable();

            for (var i = 0; i < size; i++)
                dt.Columns.Add(new DataColumn("c" + i, typeof(string)));
            for (var i = 0; i < size; i++)
            {
                var r = dt.NewRow();
                for (var c = 0; c < size; c++)
                    r[c] = "0";
                dt.Rows.Add(r);
            }

            this.Matrix = dt.DefaultView;
            PropertyChanged(this, new PropertyChangedEventArgs("Matrix"));
        }
     }
}
