using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class PageData<T>
    {
        public int Total { get; set; }

        public int PageCount { get; set; }

        public IList<T> Data { get; set; }

        public PageData<S> Copy<S>(IList<S> list)
        {
            return new PageData<S>() { Total = Total, PageCount = PageCount, Data = list };
        }
    }

    public class PageData : PageData<object>
    {

    }
}
