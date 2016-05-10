using System;
using System.Web.Http;
using TLMManager.Entity;
using TLMManager.Service;
using TLMManager.Service.Interface;

namespace TLMManager.Controller
{
    public class UserConnectionController : ApiController
    {
        private readonly IUserConnectionService _service;

        public UserConnectionController()
        {
            _service = ModelInject.Inject<IUserConnectionService>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        [HttpPost]
        public void Add([FromBody] UserConnection conn)
        {
            conn.Id = new Guid();
            _service.Add(conn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        public UserConnection Find(string username)
        {
            return _service.Get(username);
        }
        
    }
}
