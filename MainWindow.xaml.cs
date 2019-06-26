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
        BindingList <Folders> _folders = new BindingList<Folders>();
        List<IAction> _actions;
        List<Preset> arrayPresets = new List<Preset>();
        string[] filesSub;
        string[] foldersSub;
        System.Windows.Forms.FolderBrowserDialog fileData;
        System.Windows.Forms.FolderBrowserDialog folderData;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadPresets();


            //a.savePreset("testthuthoi");

            _actions = new List<IAction>()
            {
                new Replacer(){ Args = new ReplaceArgs(){OldFile = "abc", NewFile="def" }},
                new NewCase(){ Args = new NewCaseArg(){type = 1 }},
                new Move(){ Args = new MoveArgs(){ amount = 13 }},
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

        private void loadPresets()
        {
            presetComboBox.Items.Clear();
            arrayPresets.Clear();

            var path = AppDomain.CurrentDomain.BaseDirectory;
            string[] presetPaths = Directory.GetFiles(path, "*.txt");
           

            foreach (var presetPath in presetPaths)
            {
                Preset a = new Preset();
                arrayPresets.Add(a.loadPreset(presetPath));
            }

            foreach (var preset in arrayPresets)
            {
                presetComboBox.Items.Add(preset.presetName);
            }
        }



    
        //files
        private void addSysFileDialog(object sender, RoutedEventArgs e)
        {
            _files.Clear();
            fileData = new System.Windows.Forms.FolderBrowserDialog();

            if (fileData.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                filesSub = Directory.GetFiles(fileData.SelectedPath);

                foreach (var file in filesSub)
                {
                    _files.Add(new Files { Name = getNameBySplitPath(file), Path = file });
                }

                fileListView.ItemsSource = _files;
            }
        }

        private void addSysFolderDialog(object sender, RoutedEventArgs e)
        {
            _folders.Clear();
            folderData = new System.Windows.Forms.FolderBrowserDialog();

            if (folderData.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                foldersSub = Directory.GetDirectories(folderData.SelectedPath);

                foreach (var folder in foldersSub)
                {
                    _folders.Add(new Folders { Name = getNameBySplitPath(folder), Path = folder });
                }

                folderListView.ItemsSource = _folders;
            }
        }

        private void refreshFileListView()
        {
            //refresh File
            _files.Clear();

            filesSub = Directory.GetFiles(fileData.SelectedPath);

            foreach (var file in filesSub)
            {
                _files.Add(new Files { Name = getNameBySplitPath(file), Path = file });
            }
        }

        private void refreshFolderListView()
        {
            //refresh Folder
            _folders.Clear();

            foldersSub = Directory.GetDirectories(folderData.SelectedPath);

            foreach (var folder in foldersSub)
            {
                _folders.Add(new Folders { Name = getNameBySplitPath(folder), Path = folder });
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var action = actionListView.SelectedItem as IAction;
            action.ShowUpdateArgDialog();
        }

        private List<IAction> getCheckBoxValue()
        {
            List<IAction> listActions = new List<IAction>();
       
            if ((bool)newCaseCheckBox.IsChecked)
            {
                listActions.Add(_actions[0]);
            }

            if ((bool)moveCheckBox.IsChecked)
            {
                listActions.Add(_actions[1]);
            }

            if ((bool)replaceCheckBox.IsChecked)
            {
                listActions.Add(_actions[2]);
            }

            if ((bool)fullnameNormalizeCheckBox.IsChecked)
            {
                listActions.Add(_actions[3]);
            }

            if ((bool)guidCheckBox.IsChecked)
            {
                listActions.Add(_actions[4]);
            }

            return listActions;
        }

        private void startBatch(object sender, RoutedEventArgs e)
        {
            //checkBox
            List<IAction> listActions = getCheckBoxValue();
                
            if (tabFileItems.IsSelected)
            {
                if (fileListView.Items.Count == 0)
                {
                    MessageBox.Show("Listview is empty");
                    return;
                }

                foreach (var file in _files)
                {
                    var result = file.Path;

                    foreach (var act in listActions)
                    {

                        result = result.Replace(file.Name, act.Process(file.Name));
                        file.Name = getNameBySplitPath(result);

                    }
                    File.Move(file.Path, result);

                }
                refreshFileListView();
            }
            else if (tabFolderItems.IsSelected)
            {
                if (folderListView.Items.Count == 0)
                {
                    MessageBox.Show("Listview is empty");
                    return;
                }

                foreach (var folder in _folders)
                {

                    var result = folder.Path;
                    foreach (var act in listActions)
                    {

                        result = result.Replace(folder.Name, act.Process(folder.Name));
                        folder.Name = getNameBySplitPath(result);

                    }
                    string a = "aaa";
                    Directory.Move(folder.Path, a);
                    Directory.Move(a, result);
                }
                refreshFolderListView();
            }
        }

        private void savePresetButtonClick(object sender, RoutedEventArgs e)
        {
            var textBoxContent = presetNameTextBox.Text;
            if (textBoxContent.Length == 0)
                MessageBox.Show("Enter Preset name");
            else
            {
                List<IAction> listActions = getCheckBoxValue();

                Preset preset = new Preset();
                string presetName = textBoxContent;
                preset.savePreset(presetName, listActions);
                MessageBox.Show($"Preset {presetName} saved");

                loadPresets();
            }
        }

        //optional:
        private void ComboBoxSectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //show discription of this preset
            //var a = presetComboBox.SelectedIndex;
            //MessageBox.Show(a.ToString());
        }

        private void comboBoxDidDropDownClosed(object sender, EventArgs e)
        {
            var index = presetComboBox.SelectedIndex;
            _actions = arrayPresets[index].actions;
            actionListView.ItemsSource = _actions;
        }
    }
}
