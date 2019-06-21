using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    class Folders : INotifyPropertyChanged
    {
        string _name;
        string _path;
        string _newName;
        //TODO: ERROR 

        public string Name { get => _name; set => _name = value; }
        public string Path { get => _path; set => _path = value; }
        public string NewName { get => _newName; set => _newName = value; }

        public void Process(string origin, string path, IAction _action)
        {
            // _action = new NewCase() { Args = new NewCaseArg() { type = 1} };
            // File.Move(path, path.Replace(origin, _action.Process(origin)));
          
            string a = "a";
            var result = path;
            result = result.Replace(origin, _action.Process(origin));
            Directory.Move(path, a);
            Directory.Move(a, result);
           

        }
        public void replace(string originName, string newName, string path)
        {
            IAction replaceAction = new Replacer() { Args = new ReplaceArgs() { OldFile = originName, NewFile = newName } };
            Directory.Move(path, replaceAction.Process(path));
        }

        //fullname normalize
        public void fullnamenormalize(string originName, string path)
        {
            IAction fullnamenormalizeAction = new FullNameNormalize()
            { Args = new FullNameNormalizeArgs() {  } };
            string a = "aa";
            Directory.Move(path, a);
            Directory.Move(a,fullnamenormalizeAction.Process(path));
           
        }
        public void guidname(string originName, string path)
        {
            IAction guidAction = new GUIDName()
            { Args = new GUIDArgs() {  } };
            Directory.Move(path, guidAction.Process(path));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
