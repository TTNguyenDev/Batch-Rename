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

        //files
        private void addSysFileDialog(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog data = new System.Windows.Forms.FolderBrowserDialog();

            if (data.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] filesSub = Directory.GetFiles(data.SelectedPath);

                foreach (var file in filesSub)
                {
                    files.Add(new Files { Name = getNameBySplitPath(file), Path = file });
                }

                fileListView.ItemsSource = files;
            }
            
        }

        private void actionForTest()
        {
            //RenameFiles();
            //newCase();

            ////fileListView.Items.Clear();
            //files.Clear();

            //filesSub = Directory.GetFiles(data.SelectedPath);

            //foreach (var file in filesSub)
            //{
            //    files.Add(new Files { Name = getNameBySplitPath(file), Path = file });
            //}
            //// FullNameNormalizeFile();

            ////fileListView.Items.Clear();
            //files.Clear();

            //filesSub = Directory.GetFiles(data.SelectedPath);

            //foreach (var file in filesSub)
            //{
            //    files.Add(new Files { Name = getNameBySplitPath(file), Path = file });
            //}
        }



        private void newCase()
        {
            Files a = new Files();
            foreach (var file in files)
            {
                a.newCase(file.Name, file.Path);
            }
        }
        private void move()
        {
            Files a = new Files();
            foreach (var file in files)
            {
                a.move(file.Name, file.Path);
            }
        }
        private void RenameFiles()
        { 
            Files a = new Files();
            a.replace(files[0].Name, "  bHi 17hc  abv.txt", files[0].Path);
                
        }
        private void FullNameNormalizeFile()
        {
            Files a = new Files();
            foreach (var file in files)
            {
                a.fullnamenormalize(file.Name, file.Path);
            }
        }
        
        private void GuidNameFiles()
        {
            Files a = new Files();
            foreach(var file in files)
            {
                a.guidname(file.Name, file.Path);
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
                folders.Add(new Folders { Name = getNameBySplitPath(folder), Path = folder });
            }
            
            folderListView.ItemsSource = folders;
        }
        private void RenameFolders()
        {
            Folders a = new Folders();
            a.replace(folders[0].Name, " ssha hAi Yen ", folders[0].Path);
        }
        private void FullNameNormalizeFolder()
        {
            Folders a = new Folders();
            foreach (var folder in folders)
            {
                a.fullnamenormalize(folder.Name, folder.Path);
            }
        }
        private void GuidNameFolders()
        {
            Folders a = new Folders();
            foreach (var folder in folders)
            {
                a.guidname(folder.Name, folder.Path);
            }
        }

        private void handleNewCaseAction(object sender, MouseButtonEventArgs e)
        {
            IAction a = new Replacer() { Args = new ReplaceArgs() { OldFile = "icescream", NewFile = "chocolate" } };
            a.ShowUpdateArgDialog();
       
        }

        private void handleMoveAction(object sender, MouseButtonEventArgs e)
        {

        }

        private void handleReplaceAction(object sender, MouseButtonEventArgs e)
        {

        }

        private void handleFullNameNormalize(object sender, MouseButtonEventArgs e)
        {

        }

        private void handleUniqueName(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
