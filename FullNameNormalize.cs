using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    /// <summary>
    /// Hành động thay thế chuỗi
    /// </summary>
    public class FullNameNormalize : IAction, INotifyPropertyChanged
    {
        public IArgs Args { get; set; }

        public string Description
        {
            get
            {
                var args = Args as FullNameNormalizeArgs;
                var oldname = args.OldName;

                var result = $"Chuan hoa {oldname} ";
                return result;
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
            var args = Args as FullNameNormalizeArgs;
            var name = args.OldName;
            var newname = args.NewName;

            var Result = origin.Replace(name, newname);
           
            return Result;
        }

        public void ShowUpdateArgDialog()
        {
            var screen = new UpdateReplaceArgsDialog(Args as ReplaceArgs);

            if (screen.ShowDialog() == true)
            {
                //MessageBox.Show("Args changed");
                RaiseChangeEvent("Description");
            }
        }
    }
}

