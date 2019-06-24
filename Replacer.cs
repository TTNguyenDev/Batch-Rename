using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniProject_Batch_Rename
{
    /// <summary>
    /// Hành động thay thế chuỗi
    /// </summary>
    public class Replacer : IAction, INotifyPropertyChanged
    {
        public IArgs Args { get; set; }
      
        public string Description
        {
            get
            {
                var args = Args as ReplaceArgs;
                var oldfile = args.OldFile;
                var newfile = args.NewFile;

                var result = $"Replace {oldfile} to {newfile}";
                return result;
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
        /// Xử lí thay thế chuỗi
        /// </summary>
        /// <param name="origin">Chuỗi gốc</param>
        /// <returns>Chuỗi sau khi thay thế</returns>
        public string Process(string origin)
        {
            var args = Args as ReplaceArgs;
            var oldfile = args.OldFile;
            var newfile = args.NewFile;

            var result = origin.Replace(oldfile, newfile);

            return result;
        }

        public void ShowUpdateArgDialog()
        {
            var screen = new UpdateReplaceArgsDialog(Args as ReplaceArgs);

            if (screen.ShowDialog() == true)
            {
                var args = Args as ReplaceArgs;
                var oldfile = args.OldFile;
                var newfile = args.NewFile;

                MessageBox.Show(args.OldFile);
                MessageBox.Show(args.NewFile);

                RaiseChangeEvent("Description");

            }
        }
    }
}
