using AppServer.Models;
using AppServerModels;
using AppServerModels.DataBaseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServer.Controllers.Member
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppServerEntities _ase;
        public UserController(AppServerEntities ase)
        {
            _ase = ase;
        }

        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpReturnMod UpdateUserAvatar()
        {
            HttpReturnMod hrm = new HttpReturnMod();
            try
            {
                User new_user = JsonConvert.DeserializeObject<User>(Request.Form["user"]);
                User old_user = _ase.User.FirstOrDefault(u => u.UserId.Equals(new_user.UserId) && u.IsDelete == 0);
                if (old_user == null) { hrm.Msg = "用户不存在"; return hrm; }
                old_user.UserAvatar = new_user.UserAvatar;
                if (_ase.SaveChanges() > 0)
                {
                    hrm.Code = 100;
                    hrm.Msg = "修改头像成功";
                }
                else
                {
                    hrm.Msg = "修改头像失败";
                }
            }
            catch (Exception e)
            {
                hrm.Msg = "修改用户头像错误";
            }
            return hrm;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpReturnMod Login()
        {
            HttpReturnMod hrm = new HttpReturnMod();
            try
            {
                User new_user = JsonConvert.DeserializeObject<User>(Request.Form["user"]);
                User old_user = _ase.User.FirstOrDefault(u => u.UserId.Equals(new_user.UserId) && u.Password.Equals(new_user.Password));
                if (old_user == null) { hrm.Msg = "用户或密码错误"; return hrm; }
                hrm.Dic.Add("data", JsonConvert.SerializeObject(CreateDic(old_user)));
                hrm.ToUrl = "Mine";
                hrm.Code = 100;
                hrm.Msg = "登录成功";
            }
            catch (Exception e)
            {
                hrm.Msg = "登录错误";
            }
            return hrm;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpReturnMod Register()
        {
            HttpReturnMod hrm = new HttpReturnMod();
            try
            {
                User user = JsonConvert.DeserializeObject<User>(Request.Form["user"]);
                if (_ase.User.FirstOrDefault(u => u.UserId.Equals(user.UserId)) != null) { hrm.Msg = "用户已存在"; return hrm; }
                user.UserAvatar = "tx4.jpg";
                _ase.User.Add(user);
                if (_ase.SaveChanges() > 0)
                {
                    hrm.Dic.Add("data", JsonConvert.SerializeObject(CreateDic(user)));
                    hrm.ToUrl = "Mine";
                    hrm.Code = 100;
                    hrm.Msg = "注册成功";
                }
                else
                {
                    hrm.Msg = "注册失败";
                }
            }
            catch (Exception e)
            {
                hrm.Msg = "注册错误";
            }
            return hrm;
        }

        public Dictionary<string, string> CreateDic(User user)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Id", user.Id.ToString());
            dic.Add("UserId", user.UserId);
            dic.Add("UserName", user.UserName);
            dic.Add("UserTel", user.UserTel);
            dic.Add("CodeId", user.CodeId);
            dic.Add("NickName", user.NickName);
            dic.Add("UserAvatar", user.UserAvatar);
            dic.Add("CreateTime", user.CreateTime.ToString());
            return dic;
        }
    }
}
