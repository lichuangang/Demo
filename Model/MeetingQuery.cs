using Entity.Demo;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hx.Extend;
using System.Linq.Expressions;

namespace Model
{

    public partial class MeetingQuery
    {
        protected override List<Expression<Func<Meeting, bool>>> MakeWhere()
        {

            List<Expression<Func<Meeting, bool>>> where = new List<Expression<Func<Meeting, bool>>>();

            if (!string.IsNullOrEmpty(Title))
            {
                where.Add(m => m.Title.Contains(Title));
            }

            if (UseDate != null && UseDate != DateTime.MinValue)
            {

                where.Add(m => m.UseDate == UseDate);
            }
            return where;

        }

    }
}
