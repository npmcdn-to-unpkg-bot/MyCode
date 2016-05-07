using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TLMManager.Core
{
    public interface IDbHelper
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns> 
        void Add<T>(T entity) where T : class;

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update<T>(T entity) where T : class;

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factor"></param>
        /// <returns></returns>
        T Find<T>(Expression<Func<T, bool>> factor) where T : class;

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> GetList<T>() where T : class;

        /// <summary>
        /// 获取一个列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="factor"></param>
        /// <param name="orderby"></param>
        /// <param name="ascing"></param>
        /// <returns></returns>
        IQueryable<T> GetList<T, TS>(Expression<Func<T, bool>> factor, Expression<Func<T, TS>> orderby, bool ascing) where T : class;

        /// <summary>
        /// 按条件获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factor"></param>
        /// <returns></returns>
        IQueryable<T> GetList<T>(Expression<Func<T, bool>> factor) where T : class;

        /// <summary>
        /// 按ID删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// 按条件删除 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factor"></param>
        void Delete<T>(Expression<Func<T, bool>> factor) where T : class;


        /// <summary>
        /// 按条件查询是否存在   
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="facotr"></param>
        /// <returns></returns>
        bool IsExists<T>(Expression<Func<T, bool>> facotr) where T : class;

        /// <summary>
        /// 获取一个分页列表
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <typeparam name="TS">排序</typeparam>
        /// <param name="page">开始页</param>
        /// <param name="rows">第页条数</param>
        /// <param name="factor">查询条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="ascing">排序条件 true  升序，false 降序</param>
        /// <param name="totalrows">输出总页数</param>
        /// <returns></returns>
        IQueryable<T> GetSkipList<T, TS>(int page, int rows, Expression<Func<T, bool>> factor, Expression<Func<T, TS>> orderby, bool ascing, out int totalrows) where T : class;


        /// <summary>
        /// 分面获取
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="TS">排序类型</typeparam>
        /// <param name="takeRow">Top 行</param>
        /// <param name="factor">查询条件</param>
        /// <param name="orderby"></param>
        /// <param name="ascing">排序条件 true  升序，false 降序</param>
        /// <returns></returns>
        IQueryable<T> GetTopList<T, TS>(int takeRow, Expression<Func<T, bool>> factor, Expression<Func<T, TS>> orderby, bool ascing) where T : class;



        /// <summary>
        /// 按SQL 语句查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<T> SqlQuery<T>(string sql) where T : class;

        /// <summary>
        /// 按SQL 更新或删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param">
        /// SqlCommExecuteSqlCommand( UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor))
        /// </param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params object[] param);


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>返回影响数库的行数</returns>
        int Save();
    }
}
