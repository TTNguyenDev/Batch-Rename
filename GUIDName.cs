using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    public class GUIDName : IAction, INotifyPropertyChanged
    {
        public IArgs Args { get; set; }

        public string Description
        {
            get
            {
                var args = Args as GUIDArgs;
                var oldname = args.OldName;

                var result = $"GUID: {oldname}";
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
            var args = Args as GUIDArgs;
            var name = args.OldName;

            Guid newName = Guid.NewGuid();
            var Result = origin.Replace(name, newName.ToString());

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
