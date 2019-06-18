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

        public void newCase(string origin, string path)
        {
            IAction newcase = new NewCase() { Args = new NewCaseArg() { type = 3 } };
            File.Move(path,path.Replace(origin,newcase.Process(origin)));
        }

        public void move(string origin, string path)
        {

            IAction _move = new Move() { Args = new MoveArgs() { } };
            File.Move(path, path.Replace(origin, _move.Process(origin)));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void fullnamenormalize(string originName, string path)
        {
            IAction fullnamenormalizeAction = new FullNameNormalize()
            { Args = new FullNameNormalizeArgs() { OldName = originName } };
            File.Move(path, fullnamenormalizeAction.Process(path));
        }

        public void guidname(string originName, string path)
        {
            IAction guidAction = new GUIDName()
            { Args = new GUIDArgs() { OldName = originName } };
            File.Move(path, guidAction.Process(path));
        }
    }
}
