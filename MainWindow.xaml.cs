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
           
            _actions = new List<IAction>()
            {
                new NewCase(){ Args = new NewCaseArg(){type = 1 }, Check = false },
                new Move(){ Args = new MoveArgs(){ amount = 1 }, Check = false },
                new Replacer(){ Args = new ReplaceArgs(){OldFile = "Old Name", NewFile="New Name" }, Check = false},
                new FullNameNormalize(){ Args = new FullNameNormalizeArgs(){}, Check = false},
               new GUIDName(){ Args = new GUIDArgs(){ }, Check = false},
            };
            actionListView.ItemsSource = _actions;
            DataContext = this;
      
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

            foreach (var act in _actions)
            {
                if (act.Check == true)
                    listActions.Add(act);
            }
            return listActions;
        }

        private void startBatch(object sender, RoutedEventArgs e)
        {
            //checkBox
            List<IAction> listActions = getCheckBoxValue();
                
            if (tabFileItems.IsSelected)
            {
                var newFilesName = handleDuplicateFilesName();
                refreshFileListView();
                if (fileListView.Items.Count == 0)
                {
                    MessageBox.Show("Listview is empty");
                    return;
                }

                for (int i = 0; i < _files.Count; ++i)
                {
                    _files[i].NewName = newFilesName[i];
                }

                foreach (var file in _files)
                {               
                    File.Move(file.Path, file.Path.Replace(file.Name, file.NewName));  
                }
            }
            else if (tabFolderItems.IsSelected)
            {
                var newFoldersName = handleDuplicateFilesName();
                refreshFolderListView();
                if (folderListView.Items.Count == 0)
                {
                    MessageBox.Show("List folderview is empty");
                    return;
                }

                for (int i = 0; i < _files.Count; ++i)
                {
                    _folders[i].NewName = newFoldersName[i];
                }
                foreach (var folder in _folders)
                {
                    string a = "aaa";
                    Directory.Move(folder.Path, a);
                    Directory.Move(a, folder.Path.Replace(folder.Name,folder.NewName));
                }
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

        private void comboBoxDidDropDownClosed(object sender, EventArgs e)
        {
            var index = presetComboBox.SelectedIndex;

            if (index == -1) return;

            _actions = arrayPresets[index].actions;
            actionListView.ItemsSource = _actions;
        }

        private List<string> handleDuplicateFilesName()
        {
            int type;
            if ((bool)Subffix.IsChecked)
                type = 1;
            else
                type = 2;
           
            List<string> myList = new List<string>();

            foreach (var file in _files)
            {
                myList.Add(file.NewName);
            }

            var counts = myList
                .GroupBy(s => s)
                .Where(p => p.Count() > 1)
                .ToDictionary(p => p.Key, p => p.Count());

            for (int i = myList.Count - 1; i >= 0; i--)
            {
                string s = myList[i];
                if (counts.ContainsKey(s))
                { 
                    if (type == 1)
                        myList[i] = $"({counts[s]--})" + myList[i];
                    else if (type == 2)
                        myList[i] = _files[i].Name;
                }
            }
            
            for (int i = 0; i < _files.Count; ++i)
            {
                _files[i].NewName = myList[i];
            }

            return myList;
        }

        private List<string> handleDuplicateFoldersName()
        {
            int type;
            if ((bool)Subffix.IsChecked)
                type = 1;
            else
                type = 2;

            List<string> myList = new List<string>();

            foreach (var folder in _folders)
            {
                myList.Add(folder.NewName);
            }

            var counts = myList
                .GroupBy(s => s)
                .Where(p => p.Count() > 1)
                .ToDictionary(p => p.Key, p => p.Count());

            for (int i = myList.Count - 1; i >= 0; i--)
            {
                string s = myList[i];
                if (counts.ContainsKey(s))
                {
                    if (type == 1)
                        myList[i] = $"({counts[s]--})" + myList[i];
                    else if (type == 2)
                        myList[i] = _files[i].Name;
                }
            }

            for (int i = 0; i < _files.Count; ++i)
            {
                _folders[i].NewName = myList[i];
            }
            return myList;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
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
                    var oldname = file.Name;
                    foreach (var act in _actions)
                    {
                        if (act.Check == true)
                        {
                            result = result.Replace(file.Name, act.Process(file.Name));
                            file.Name = getNameBySplitPath(result);
                        }
                    }
                    file.NewName = getNameBySplitPath(result);
                    file.Name = oldname;
                }
                //handle duplicate name
                handleDuplicateFilesName();
            }
            else if (tabFolderItems.IsSelected)
            {
                if (folderListView.Items.Count == 0)
                {
                    MessageBox.Show("List folderview is empty");
                    return;
                }

                foreach (var folder in _folders)
                {
                    var result = folder.Path;
                    var oldname = folder.Name;
                    foreach (var act in _actions)
                    {
                        if (act.Check == true)
                        {
                            result = result.Replace(folder.Name, act.Process(folder.Name));
                            folder.Name = getNameBySplitPath(result);
                        }
                    }
                    folder.Name = oldname;
                    folder.NewName = getNameBySplitPath(result);                   
                }
                handleDuplicateFoldersName();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (tabFileItems.IsSelected)
            {
                //refreshFileListView();
                if (fileListView.Items.Count == 0)
                {
                    MessageBox.Show("Listview is empty");
                    return;
                }

                foreach (var file in _files)
                {
                    var result = file.Path;
                    var oldname = file.Name;
                    foreach (var act in _actions)
                    {
                        if (act.Check == true)
                        {
                            result = result.Replace(file.Name, act.Process(file.Name));
                            file.Name = getNameBySplitPath(result);
                        }
                    }
                    file.NewName = getNameBySplitPath(result);
                    file.Name = oldname;
                }

            }
            else if (tabFolderItems.IsSelected)
            {
                refreshFolderListView();
                if (folderListView.Items.Count == 0)
                {
                    MessageBox.Show("List folderview is empty");
                    return;
                }

                foreach (var folder in _folders)
                {
                    var result = folder.Path;
                    var oldname = folder.Name;
                    foreach (var act in _actions)
                    {
                        if (act.Check == true)
                        {
                            result = result.Replace(folder.Name, act.Process(folder.Name));
                            folder.Name = getNameBySplitPath(result);
                        }
                    }
                    folder.Name = oldname;
                    folder.NewName = getNameBySplitPath(result);
                }
            }
        }
    }
}
