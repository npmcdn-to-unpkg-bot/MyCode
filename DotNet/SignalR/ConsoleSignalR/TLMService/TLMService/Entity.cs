using System.Collections.Generic;

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
