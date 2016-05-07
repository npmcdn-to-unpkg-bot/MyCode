using System.Data.Entity;
using System.Data.Entity.SqlServer;

#region 自用namespace
using TLMManager.Entity;
#endregion endregion


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
            var instance = SqlProviderServices.Instance;
        }
    }
}
