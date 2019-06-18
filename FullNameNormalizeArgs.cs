using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    /// <summary>
    /// Đối số của việc xử lí
    /// </summary>

    /// <summary>
    /// Lớp chứa đối số của việc thay thế
    /// </summary>
    public class FullNameNormalizeArgs : IArgs
    {
        /// <summary>
        /// Chuỗi cần phải tìm
        /// </summary>
        public string OldName { get; set; }
        /// <summary>
        /// Chuỗi phải thay thế
        /// </summary>
        public string NewName { get; set; }

    }
}
