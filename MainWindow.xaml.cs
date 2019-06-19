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

        BindingList<Files> _files = new BindingList<Files>();
        BindingList<Folders> _folders = new BindingList<Folders>();
        List<IAction> _actions = new List<IAction>();
        string[] filesSub;
        System.Windows.Forms.FolderBrowserDialog data;

        private string getNameBySplitPath(string path)
        {
            string[] result = path.Split('\\');
            return result.Last();
        }

        //files
        private void addSysFileDialog(object sender, RoutedEventArgs e)
        {
           
            data = new System.Windows.Forms.FolderBrowserDialog();

            if (data.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filesSub = Directory.GetFiles(data.SelectedPath);

                foreach (var file in filesSub)
                {
                    _files.Add(new Files { Name = getNameBySplitPath(file), Path = file });
                }

                fileListView.ItemsSource = _files;
            }
        }

        //folder
        private void addSysFolderDialog(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog data = new System.Windows.Forms.FolderBrowserDialog();
            data.ShowDialog();

            string[] foldersSub = Directory.GetDirectories(data.SelectedPath);

            foreach (var folder in foldersSub)
            {
                _folders.Add(new Folders { Name = getNameBySplitPath(folder), Path = folder });
            }
            
            folderListView.ItemsSource = _folders;
        }
        private void RenameFolders()
        {
            Folders a = new Folders();
            a.replace(_folders[0].Name, " ssha hAi Yen ", _folders[0].Path);
        }
        private void FullNameNormalizeFolder()
        {
            Folders a = new Folders();
            foreach (var folder in _folders)
            {
                a.fullnamenormalize(folder.Name, folder.Path);
            }
        }
        private void GuidNameFolders()
        {
            Folders a = new Folders();
            foreach (var folder in _folders)
            {
                a.guidname(folder.Name, folder.Path);
            }
        }

        private void handleNewCaseAction(object sender, MouseButtonEventArgs e)
        {
            IAction a = new NewCase() { Args = new NewCaseArg() { type = 1 } };
            a.ShowUpdateArgDialog();
        }

        private void handleReplaceAction(object sender, MouseButtonEventArgs e)
        {
            IAction a = new Replacer() { Args = new ReplaceArgs() { OldFile = "triet", NewFile = "yen" } };
            a.ShowUpdateArgDialog();

        }

        private void refreshListView()
        {
            _files.Clear();

            filesSub = Directory.GetFiles(data.SelectedPath);

            foreach (var file in filesSub)
            {
                _files.Add(new Files { Name = getNameBySplitPath(file), Path = file });
            }
        }

        private void startBatch(object sender, RoutedEventArgs e)
        {
            if (fileListView.Items.Count == 0)
            {
                MessageBox.Show("ListView is Empty");
                return;
            }

            Files fileInstance = new Files();
            Folders folderInstance = new Folders();
            if ((bool)newCaseCheckBox.IsChecked)
            { 
                foreach (var file in _files)
                {
                    fileInstance.newCase(file.Name, file.Path);
                }
            }

            if ((bool)moveCheckBox.IsChecked) {
                foreach (var file in _files)
                {
                    fileInstance.move(file.Name, file.Path);
                }
            }

            if ((bool)replaceCheckBox.IsChecked)
            {
              
                foreach (var file in _files)
                {
                    fileInstance.replace("khung", "hahaha nnnn", file.Path);
                }
            }

            if ((bool)fullnameNormalizeCheckBox.IsChecked)
            {
              
                foreach (var file in _files)
                {
                    fileInstance.fullnamenormalize(file.Name, file.Path);
                }
            }

            if ((bool)uniqueNameCheckBox.IsChecked)
            {
               
                foreach (var file in _files)
                {
                    fileInstance.guidname(file.Name, file.Path);
                }
            }

            refreshListView();
            MessageBox.Show("THANH CONG");

        }
    }
}
