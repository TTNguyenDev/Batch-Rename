using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Batch_Rename
{
    /// <summary>
    /// Giao diện thao tác với chuỗi tổng quát
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Đối số của việc xử lí
        /// </summary>
        IArgs Args { get; set; }

        /// <summary>
        /// Hàm xử lí chuỗi
        /// </summary>
        /// <param name="origin">Chuỗi gốc</param>
        /// <returns>Kết quả sau khi xử lí</returns>
        string Process(string origin);

        /// <summary>
        ///  Mô tả về hành động
        /// </summary>
        /// <returns></returns>
        string Description { get; }

        /// <summary>
        /// Hiển thị dialog để thay đổi đối số
        /// </summary>
        void ShowUpdateArgDialog();
    }
}
