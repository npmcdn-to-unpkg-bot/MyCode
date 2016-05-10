using System.Data.Entity;
using TLMManager.Entity;

namespace TLMManager.Core
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class TLMContext : DbContext
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
        public DbSet<UserConnection> UserConnection { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }


        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
