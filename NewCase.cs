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
        
        public string Description
        {
            get
            {
                var arg = Args as NewCaseArg;
                var result = $"Newcase with type {arg.type}";
                return result;
            }
        }

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
            if (arg.type == 1)
                result = origin.ToUpper();
            else if (arg.type == 2)
                result = origin.ToLower();
            else if(arg.type == 3)
            {

                origin = origin.Trim();
                string[] SubName = origin.Split(' ');
                for (int i = 0; i < SubName.Length; i++)
                {
                    var FirstChar = SubName[i].Substring(0, 1);
                    var OtherChar = SubName[i].Substring(1);
                    SubName[i] = FirstChar.ToUpper() + OtherChar.ToLower();
                    result += SubName[i] + " ";
                }
             
                
            }
            return result.Trim();
        }

        public void ShowUpdateArgDialog()
        {
            var screen = new UpdateNewCaseArgsDialog(Args as NewCaseArg);

            if (screen.ShowDialog() == true)
            {
                var args = Args as NewCaseArg;

                RaiseChangeEvent("Description");

            }
        }
    }
}
