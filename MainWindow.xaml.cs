﻿using System;
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
        List<IAction> _actions;
        string[] filesSub;
        System.Windows.Forms.FolderBrowserDialog data;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            _actions = new List<IAction>()
            {
                new NewCase(){ Args = new NewCaseArg(){type = 2 }},
                new Move(){ Args = new MoveArgs(){ amount = 13 }},
                new Replacer(){ Args = new ReplaceArgs(){OldFile = "old name", NewFile="new name" }},
                new FullNameNormalize(){ Args = new FullNameNormalizeArgs(){}},
                new GUIDName(){ Args = new GUIDArgs(){ }},
            };
            actionListView.ItemsSource = _actions;
           
        }
        private string getNameBySplitPath(string path)
        {
            string[] result = path.Split('\\');
            return result.Last();
        }

        //files
        private void addSysFileDialog(object sender, RoutedEventArgs e)
        {
            _files.Clear();
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



        private void refreshListView()
        {
            _files.Clear();

            filesSub = Directory.GetFiles(data.SelectedPath);

            foreach (var file in filesSub)
            {
                _files.Add(new Files { Name = getNameBySplitPath(file), Path = file });
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var action = actionListView.SelectedItem as IAction;
            action.ShowUpdateArgDialog();
        }


        


    private void startBatch(object sender, RoutedEventArgs e)
        {
            //if (fileListView.Items.Count == 0)
            // {
            //     MessageBox.Show("ListView is Empty");
            //    return;
            // }

            //foreach (var file in _files)
            //{
            //    var result = file.Path;

            //    foreach (var act in _actions)
            //    {
            //        result = result.Replace(file.Name, act.Process(file.Name));
            //        file.Name = getNameBySplitPath(result);
            //    }
            //    File.Move(file.Path, result);
            //}
            foreach (var folder in _folders)
            {

                var result = folder.Path;
                foreach (var act in _actions)
                {

                    result = result.Replace(folder.Name, act.Process(folder.Name));
                    folder.Name = getNameBySplitPath(result);

                }
                string a = "aaa";
                Directory.Move(folder.Path, a);
                Directory.Move(a, result);
            }


            //}





            //MessageBox.Show(actionListView.Items.Count.ToString());
            //refreshListView();

        }

    }
}
