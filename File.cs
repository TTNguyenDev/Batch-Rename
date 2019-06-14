using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    class File : INotifyPropertyChanged
    {
        string _name;
        string _path;
        string _newName;
        //TODO: error
        //test 
        public string Name { get => _name; set => _name = value; }
        public string Path { get => _path; set => _path = value; }
        public string NewName { get => _newName; set => _newName = value; }

        public event PropertyChangedEventHandler PropertyChanged;



    }
}
