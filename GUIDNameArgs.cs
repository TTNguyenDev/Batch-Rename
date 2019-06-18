using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    public class GUIDArgs : IArgs
    {
        /// <summary>
        /// Chuỗi cần phải tìm
        /// </summary>
        public string OldName { get; set; }
    }
}
