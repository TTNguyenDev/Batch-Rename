using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    class Files : INotifyPropertyChanged
    {
        string _name;
        string _path;
        string _newName;
        //TODO: error
        //test kkkkkkk
        public string Name { get => _name; set => _name = value; }
        public string Path { get => _path; set => _path = value; }
        public string NewName { get => _newName; set => _newName = value; }

        public void replace(string originName, string newName, string path) 
        {
            IAction replaceAction = new Replacer() { Args = new ReplaceArgs() { OldFile = originName, NewFile = newName } };
            File.Move(path, replaceAction.Process(path));
        }

        public event PropertyChangedEventHandler PropertyChanged;



    }
}
