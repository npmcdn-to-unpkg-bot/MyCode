using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLMManager.Entity
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FromUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ToUser { get; set; }

        /// <summary>
        /// 信息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 信息添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 是否已发送
        /// </summary>
        public bool Flag { get; set; } 
    }

    [NotMapped]
    public class CurrentUser
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string Empo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 连接编号
        /// </summary>
        public string ConnectionId { get; set; }
    }

    [NotMapped]
    public class MessageUser
    {
        public string ToUser { get; set; }
        public string FromUser { get; set; }
    }

    [NotMapped]
    public class MessageInfo
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string ConnectionId { get; set; }

        public string Avator { get; set; }
    }
}
