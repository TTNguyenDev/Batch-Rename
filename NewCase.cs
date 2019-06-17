using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    class NewCase : IAction, INotifyPropertyChanged
    {
        public IArgs Args { get; set; }
        /// <summary>
        /// type: các option
        /// </summary>

        public string Description => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
        void RaiseChangeEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        /// <summary>
        /// Xử lí chuỗi với option newCase type =1 hoa , type= 2 thường, type =3 chữ đầu hoa
        /// </summary>
        /// <param name="origin"> chuỗi cần xử lý</param>
        /// <returns></returns>
        public string Process(string origin)
        {
            var arg = Args as NewCaseArg;

            var result = "";
            if (arg.Type == 1)
                result = origin.ToUpper();
            else if (arg.Type == 2)
                result = origin.ToLower();
            else if (arg.Type == 3)
            {

                origin = origin.Trim();
                origin.ToLower();
                string[] SubName = origin.Split(' ');
                for (int i = 0; i < SubName.Length; i++)
                {
                    var FirstChar = SubName[i].Substring(0, 1);
                    var OtherChar = SubName[i].Substring(1);
                    SubName[i] = FirstChar.ToUpper() + OtherChar.ToLower();
                    result += SubName[i] + " ";
                }
            }
            return result;
        }

        public void ShowUpdateArgDialog()
        {
            throw new NotImplementedException();
        }
    }
}
