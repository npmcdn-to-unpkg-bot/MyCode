using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TLMManager.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class DbHelper : IDbHelper
    {
        private readonly TLMContext _db = Dbfactory.GetCurrentContext();

        public T Find<T>(Expression<Func<T, bool>> factor) where T : class
        {
            return _db.Set<T>().FirstOrDefault(factor);
        }

        public IQueryable<T> GetList<T>() where T : class
        {
            return _db.Set<T>();
        }

        public IQueryable<T> GetList<T>(Expression<Func<T, bool>> factor) where T : class
        {
            return _db.Set<T>().Where(factor);
        }


        public void Add<T>(T entity) where T : class
        {
            _db.Entry(entity).State = EntityState.Added;
        }

        public void Update<T>(T entity) where T : class
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Delete<T>(T entity) where T : class
        {


            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Deleted;
        }


        public void Delete<T>(Expression<Func<T, bool>> factor) where T : class
        {
            var list = GetList(factor);
            foreach (var item in list)
            {
                _db.Entry(item).State = EntityState.Deleted;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="factor"></param>
        /// <param name="orderby"></param>
        /// <param name="ascing"></param>
        /// <param name="totalrows"></param>
        /// <returns></returns>
        public IQueryable<T> GetSkipList<T, TS>(int page, int rows, Expression<Func<T, bool>> factor, Expression<Func<T, TS>> orderby, bool ascing, out int totalrows) where T : class
        {
            var list = GetList(factor, orderby, ascing);
            totalrows = list != null ? list.Count() : 0;
            if (list != null)
            {
                list = list.Skip((page - 1) * rows).Take(rows);           
            }
            return list;
        }


        /// <summary>
        /// 按SQL条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<T> SqlQuery<T>(string sql) where T : class
        {
            return _db.Database.SqlQuery<T>(sql).ToList();
        }

        /// <summary>
        /// 按SQL 更新或删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, params object[] param)
        {
            return _db.Database.ExecuteSqlCommand(sql, param);
        }



        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="factor"></param>
        /// <param name="orderby"></param>
        /// <param name="ascing"></param>
        /// <returns></returns>
        public IQueryable<T> GetList<T, TS>(Expression<Func<T, bool>> factor, Expression<Func<T, TS>> orderby, bool ascing) where T : class
        {
            IQueryable<T> list = _db.Set<T>();
            if (factor != null)
            {
                list = list.Where(factor);
            }
            if (orderby != null)
            {
                list = ascing ? list.OrderBy(@orderby) : list.OrderByDescending(@orderby);
            }
            return list;
        }



        public int Save()
        {
            return _db.SaveChanges();
        }



        /// <summary>
        /// 分面获取
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="TS">排序类型</typeparam>
        /// <param name="takeRow">Top 行</param>
        /// <param name="factor">查询条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="ascing">true 升序，false 降序</param>
        /// <returns></returns>
        public IQueryable<T> GetTopList<T, TS>(int takeRow, Expression<Func<T, bool>> factor, Expression<Func<T, TS>> orderby, bool ascing) where T : class
        {
            IQueryable<T> list = _db.Set<T>();
            if (factor != null)
            {
                list = list.Where(factor);
            }
            if (orderby != null)
            {
                list = ascing ? list.OrderBy(@orderby) : list.OrderByDescending(@orderby);
            }

            return list.Take(takeRow);
        }

        bool IDbHelper.IsExists<T>(Expression<Func<T, bool>> facotr)
        {
            return _db.Set<T>().Any(facotr);
        }

    }
}
