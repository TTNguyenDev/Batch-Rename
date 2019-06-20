using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    class Move : IAction, INotifyPropertyChanged
    {
        public IArgs Args { get; set; }

        public string Description => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Move ISBN 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public string Process(string origin)
        {
            var arg = Args as MoveArgs;
            //var iSBN = arg.ISBN;
            int last = origin.LastIndexOf('.');
            string newStringProcess = origin.Substring(0, last);
            string endFile = origin.Substring(last);
            string iSBN = newStringProcess.Substring(0, 13);
            string fileName = newStringProcess.Substring(13);
            origin = origin.Replace(fileName, iSBN);

            var result = fileName + " " + origin.Substring(13);
            return result.Trim();
        }

        public void ShowUpdateArgDialog()
        {
            return;
        }
    }


}
