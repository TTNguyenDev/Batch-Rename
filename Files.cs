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
        public string NewName { get => _newName;
            set
            {
                _newName = value;
                RaiseChangeEvent("NewName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaiseChangeEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public void Process(  string origin,  string path, IAction _action)
        {
            // _action = new NewCase() { Args = new NewCaseArg() { type = 1} };
            // File.Move(path, path.Replace(origin, _action.Process(origin)));
            var result = path;

            result = result.Replace(origin, _action.Process(origin));
            File.Move(path, result);
            

        }

        
    }
}

