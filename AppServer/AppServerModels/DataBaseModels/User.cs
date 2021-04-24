using System;
using System.Collections.Generic;

namespace AppServerModels.DataBaseModels
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserTel { get; set; }
        public string CodeId { get; set; }
        public string NickName { get; set; }
        public string UserAvatar { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int IsDelete { get; set; }
    }
}
