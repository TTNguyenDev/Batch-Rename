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

        public void replace(string originName, string newName, string path)
        {
            IAction replaceAction = new Replacer() { Args = new ReplaceArgs() { OldFile = originName, NewFile = newName } };
            Directory.Move(path, replaceAction.Process(path));
        }

        //fullname normalize
        public string _FullNameNormalize(string name)
        {
            var Result = "";
            name = name.Trim();

            while (name.IndexOf("  ") != -1)
            {
                name = name.Replace("  ", " ");
            }
            var SubName = name.Split(' ');
            for (int i = 0; i < SubName.Length; i++)
            {
                var FirstChar = SubName[i].Substring(0, 1);
                var OtherChar = SubName[i].Substring(1);
                SubName[i] = FirstChar.ToUpper() + OtherChar.ToLower();
                Result += SubName[i] + " ";
            }
            return Result;
        }
        public void fullnamenormalize(string originName, string path)
        {
            //int b = 0;
            string newname = _FullNameNormalize(originName);
            IAction fullnamenormalizeAction = new FullNameNormalize()
            { Args = new FullNameNormalizeArgs() { OldName = originName, NewName = newname } };
            string a = "aa";
            Directory.Move(path, a);
            Directory.Move(a, fullnamenormalizeAction.Process(path));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
