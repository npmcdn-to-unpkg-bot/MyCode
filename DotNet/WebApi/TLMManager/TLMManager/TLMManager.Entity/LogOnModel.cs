using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region 自有namespace

#endregion

namespace TLMManager.Entity
{
    [NotMapped]
    public class LogOnModel
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public bool isRemenberMe { get; set; }
    }
}
