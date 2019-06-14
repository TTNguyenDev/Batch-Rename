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

        BindingList<Files> files = new BindingList<Files>();
        BindingList<Folders> folders = new BindingList<Folders>();

        private string getNameBySplitPath(string path)
        {
            string[] result = path.Split('\\');
            return result.Last();
        }

        private string getMainPath(string path)
        {
            string[] result = path.Split('\\');
            foreach (var r in result)
            {

            }
            return result.Last();
        }


        //files
        private void addSysFileDialog(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog data = new System.Windows.Forms.FolderBrowserDialog();
            data.ShowDialog();

            string[] filesSub = Directory.GetFiles(data.SelectedPath);


            foreach (var file in filesSub)
            {
                files.Add(new Files { Name = getNameBySplitPath(file), Path = file });
            }

            fileListView.ItemsSource = files;
            RenameFiles();
        }
        private void RenameFiles()
        {
            var oldName = files[0].Path;
            var newName = "D:\\test.txt";
            File.Move(oldName, newName);
            MessageBox.Show("File named changed!");
        }
        //folder
        private void addSysFolderDialog(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog data = new System.Windows.Forms.FolderBrowserDialog();
            data.ShowDialog();

            string[] foldersSub = Directory.GetDirectories(data.SelectedPath);

            foreach (var folder in foldersSub)
            {
                folders.Add(new Folders { Name = getNameBySplitPath(folder), Path = folder });
            }

            folderListView.ItemsSource = folders;
            RenameFolders();
        }
        private void RenameFolders()
        {

            var oldName = folders[0].Path;
            var newName = "D:\\trash\\trash3";
            Directory.Move(oldName, newName);
            MessageBox.Show("File named changed!");
        }
    }
}