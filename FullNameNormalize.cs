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
                

                var result = $"Fullname normalize";
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
        public string _FullNameNormalize(string name)
        {
            var _result = "";
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
                _result += SubName[i] + " ";
            }
            _result = _result.Trim();
            return _result;
        }
        public string Process(string origin)
        {
            var args = Args as FullNameNormalizeArgs;
                    
            var Result = origin.Replace(origin, _FullNameNormalize(origin));          
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
