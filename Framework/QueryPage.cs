using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class QueryPage<T>
    {
        private int _pageIndex = 1;
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public string Sort { get; set; }

        public bool IsAsc { get; set; }

        public PageData<T> Result { get; set; }

        public List<Expression<Func<T, bool>>> where
        {
            get
            {
                return MakeWhere();
            }
        }

        protected virtual List<Expression<Func<T, bool>>> MakeWhere()
        {
            return null;
        }
    }

    public class QueryPage : QueryPage<object>
    {

    }
}
