using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace MiniProject_Batch_Rename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        BindingList<File> files = new BindingList<File>();
        BindingList<Folder>
        private void addSysFileDialog(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog data = new System.Windows.Forms.FolderBrowserDialog();
            data.ShowDialog();

            string[] filesSub = Directory.GetFiles(data.SelectedPath);
            string[] folders = Directory.GetDirectories(data.SelectedPath);

            foreach(var file in filesSub)
            {
                files.Add(new File { Name = file, Path = file });
            }

            fileListView.ItemsSource = files;
        }
    }
}
