using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TLMManager.Entity;

namespace TLMManager.Core
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public partial class TLMContext : DbContext
    {
        static TLMContext()
        {
            Database.SetInitializer<TLMContext>(null);
        }

        public TLMContext()
            : base("name=TLMContext")
        {
            // 禁用延迟加载
            //base.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<Message> UserMessage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }


        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
