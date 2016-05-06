using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLMManager.Entity
{
    [Table("SystemUser")]
    public class SystemUser
    {
        [Key]
        public Guid SystemUserId { get; set; }

        public Guid BusinessUnitId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }

        public int? Sex { get; set; }
        [MaxLength(20)]
        public string Mobile { get; set; }
        [MaxLength(20)]
        public string OfficeTel { get; set; }

        public int? DeletionStateCode { get; set; }

        public int? statecode { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(500)]
        public string Password { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid ModifiedBy { get; set; }

        public Guid OwningUser { get; set; }
        
        public Guid OwningBusinessUnit { get; set; }
        [MaxLength(20)]
        public string TLM_empno { get; set; }
        [MaxLength(20)]
        public string TLM_qq { get; set; }
        [MaxLength(200)]
        public string TLM_email { get; set; }
        [MaxLength(200)]
        public string TLM_userimg { get; set; }

    }
}
