using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Common
{
    public class PaginationResult<T>
    {
        /// <summary>
        /// 总数据量
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 当前分页的数据集合
        /// </summary>
        public IEnumerable<T> Array { get; set; }

    }
}
