using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    class Folder : INotifyPropertyChanged
    {
        string _name;
        string _path;
        string _newName;
        //TODO: ERROR 

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
