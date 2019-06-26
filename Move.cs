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

        public override string ToString()
        {
            return "move";
        }

        public string Description
        {
            get
            {
                var arg = Args as MoveArgs;
                return $"Move";
            }
        }

        private bool check;
        public bool Check
        {
            get => check;
            set
            {
                check = value;
                RaiseChangeEvent("Check");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaiseChangeEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        /// <summary>
        /// Move ISBN 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public string Process(string origin)
        {
            var arg = Args as MoveArgs;
            //var iSBN = arg.ISBN;
            origin = origin.Trim();
            int i = 0;
            foreach(var ori in origin)
            {
                if (ori == '.')
                    i++;

            }
            var result = "";
            
            if (i != 0)
            {
                string newStringProcess = origin.Substring(0, origin.LastIndexOf('.'));
                string endFile = origin.Substring(origin.LastIndexOf('.'));
                string iSBN = origin.Substring(0, arg.amount);
                string fileName = newStringProcess.Substring(arg.amount);
                origin = origin.Replace(fileName, iSBN);

                // var result = fileName + " " + origin.Substring(arg.amount).Trim();
                result = fileName.Trim() + " " + iSBN.Trim() + endFile.Trim();
            }
            else
            {
                string iSBN = origin.Substring(0, arg.amount);
                string fileName = origin.Substring(arg.amount);
                origin = origin.Replace(fileName, iSBN);
                result = fileName.Trim() + " " + iSBN.Trim();
            }

            /*string newStringProcess = origin.Substring(0, origin.LastIndexOf('.'));
            string endFile = origin.Substring(origin.LastIndexOf('.'));
            string iSBN = origin.Substring(0, arg.amount);
            string fileName = newStringProcess.Substring(arg.amount);
            origin = origin.Replace(fileName, iSBN);

            // var result = fileName + " " + origin.Substring(arg.amount).Trim();
            var result = fileName.Trim()+" " + iSBN.Trim() + endFile.Trim();*/
            return result.Trim();
        }

        public void ShowUpdateArgDialog()
        {
            var screen = new UpdateMoveArgsDialog(Args as MoveArgs);

            if (screen.ShowDialog() == true)
            {
                var args = Args as MoveArgs;

                RaiseChangeEvent("Description");

            }
        }
    }


}
