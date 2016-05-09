using System.ComponentModel.DataAnnotations.Schema;

#region 自有namespace

#endregion

namespace TLMManager.Entity
{
    [NotMapped]
    public class LogOnModel
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public bool IsRemenberMe { get; set; }
    }
}
