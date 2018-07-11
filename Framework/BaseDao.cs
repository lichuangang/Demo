using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using System.Linq.Expressions;

namespace Framework
{
    public class BaseDao<T> where T : class, new()
    {

        #region 查询

        public void Any(Expression<Func<T, bool>> where, bool isRead = true)
        {
            using (var db = GetDbInstance(isRead))
            {
                db.Queryable<T>().Any(where);
            }
        }

        public T Get(Expression<Func<T, bool>> where, bool isRead = true)
        {
            using (var db = GetDbInstance(isRead))
            {
                return db.Queryable<T>().First(where);
            }
        }

        public void Page(QueryPage<T> query, bool isRead = true)
        {
            using (var db = GetDbInstance(isRead))
            {
                var source = db.Queryable<T>();
                //排序
                if (!string.IsNullOrWhiteSpace(query.Sort))
                {
                    source = source.OrderBy(query.Sort + (query.IsAsc ? " asc" : " desc"));
                }
                else
                {
                    source = source.OrderBy("ID asc");

                }
                //是否有where条件
                if (query.where != null && query.where.Count > 0)
                {
                    query.where.ForEach(where =>
                    {
                        source = source.Where(where);
                    });
                }
                //分页
                PageData<T> pageData = new PageData<T>();
                //总条数
                pageData.Total = source.Count();
                //计算页数
                pageData.PageCount = (pageData.Total + query.PageSize - 1) / query.PageSize;
                //数据
                pageData.Data = source.Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList();

                query.Result = pageData;
            }
        }

        public IList<T> Top(int count, bool isRead = true)
        {
            using (var db = GetDbInstance(isRead))
            {
                return db.Queryable<T>().Take(count).ToList();
            }
        }

        /// <summary>
        /// 查询所有，对数据量比较大的表，谨慎使用
        /// </summary>
        public IList<T> ToList(bool isRead = true)
        {
            using (var db = GetDbInstance(isRead))
            {
                return db.Queryable<T>().ToList();
            }
        }

        public IList<T> ToList(Expression<Func<T, bool>> where, bool isRead = true)
        {
            using (var db = GetDbInstance(isRead))
            {
                return db.Queryable<T>().Where(where).ToList();
            }
        }
        #endregion

        #region 增加、编辑、删除
        public void Add(T entity)
        {
            using (var db = GetDbInstance(false))
            {
                db.Insertable<T>(entity);
            }
        }

        public void AddRange(List<T> list)
        {
            using (var db = GetDbInstance(false))
            {
                db.Insertable<T>(list);
            }
        }

        public void Edit(T entity)
        {
            using (var db = GetDbInstance(false))
            {
                db.Updateable(entity);
            }
        }

        public void Edit(object obj, Expression<Func<T, bool>> where)
        {
            using (var db = GetDbInstance(false))
            {
                //db.Updateable<T>(obj, where);
            }
        }

        public void EditRange(List<T> list)
        {
            using (var db = GetDbInstance(false))
            {
                //db.UpdateRange<T>(list);
            }

        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        public void Delete(Expression<Func<T, bool>> where)
        {
            using (var db = GetDbInstance(false))
            {
                db.Deleteable<T>(where);
            }
        }

        /// <summary>
        /// 根据主键的类型进行删除
        /// </summary>
        public void Delete<KType>(KType key)
        {
            using (var db = GetDbInstance(false))
            {
                db.Deleteable<T>(key);
            }
        }


        #endregion

        #region 公用方法
        protected SqlSugarClient GetDbInstance(bool isRead = true)
        {
            var dbName = DbName;
            //切换到写库
            if (isRead == false)
            {
                dbName = dbName + "_write";
            }
            return SugarFactory.GetInstance(dbName);
        }
        #endregion

        #region 字段

        //该方法可以获取到子类的命名空间后缀名－－db的名称
        private string DbName
        {
            get
            {
                string dbName = string.Empty;
                var type = this.GetType();
                //从特性中获取数据库名
                object obj = type.GetCustomAttributes(typeof(DbNameAttribute), true).FirstOrDefault();
                if (obj != null)
                {
                    DbNameAttribute dbat = obj as DbNameAttribute;
                    dbName = dbat.DbName;
                }
                else//如果未设置特性，直接取命名空间最后一级
                {
                    var space = type.Namespace;
                    dbName = space.Split('.').Last();
                }

                return dbName;
            }

        }
        #endregion

    }
}
