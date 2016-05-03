using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TLMService
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrentUser
    {
        public string ConnectionId { get; set; }

        public string UserName { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class MessageDetail
    {
        public string UserName { get; set; }

        public string Message { get; set; }
    }
}
