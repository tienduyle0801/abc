using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion
{
    [Serializable]
    public class UserLogin
    {
        public long UserId { set; get; }
        public string UserName { set; get; }
        public string GroupId { set; get; }
    }
}