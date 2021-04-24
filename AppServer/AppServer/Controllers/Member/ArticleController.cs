using AppServer.Models;
using AppServerModels.DataBaseModels;
using Expansion.ObjUpdateMethod;
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
    public class ArticleController : ControllerBase
    {
        private readonly AppServerEntities _ase;
        public ArticleController(AppServerEntities ase)
        {
            _ase = ase;
        }

        /// <summary>
        /// 发布文章
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpReturnMod Add()
        {
            HttpReturnMod hrm = new HttpReturnMod();
            try
            {
                User user = _ase.User.FirstOrDefault(u => u.UserId.Equals(Request.Form["userid"]) && u.IsDelete == 0);
                if (user == null) { hrm.Msg = "用户不存在"; return hrm; }
                Article article = JsonConvert.DeserializeObject<Article>(Request.Form["article"]);
                article.Uid = user.Id;
                _ase.Article.Add(article);
                if (_ase.SaveChanges() > 0)
                {
                    hrm.ToUrl = "Mine";
                    hrm.Code = 100;
                    hrm.Msg = "发布成功";
                }
                else
                {
                    hrm.Msg = "发布失败";
                }
            }
            catch (Exception e)
            {
                hrm.Msg = "发布文章错误";
            }
            return hrm;
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpReturnMod Update()
        {
            HttpReturnMod hrm = new HttpReturnMod();
            try
            {
                User user = _ase.User.FirstOrDefault(u => u.UserId.Equals(Request.Form["userid"]) && u.IsDelete == 0);
                if (user == null) { hrm.Msg = "用户不存在"; return hrm; }
                Article new_article = JsonConvert.DeserializeObject<Article>(Request.Form["article"]);
                Article old_article = _ase.Article.FirstOrDefault(a => a.Id == new_article.Id && a.Uid == user.Id && a.IsDelete == 0);
                if (old_article == null) { hrm.Msg = "文章不存在"; return hrm; }
                Obj.Update(old_article, new_article);
                if (_ase.SaveChanges() > 0)
                {
                    hrm.Code = 100;
                    hrm.Msg = "修改成功";
                }
                else
                {
                    hrm.Msg = "修改失败";
                }
            }
            catch (Exception e)
            {
                hrm.Msg = "修改文章错误";
            }
            return hrm;
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpReturnMod Del()
        {
            HttpReturnMod hrm = new HttpReturnMod();
            try
            {
                User user = _ase.User.FirstOrDefault(u => u.UserId.Equals(Request.Form["userid"]) && u.IsDelete == 0);
                if (user == null) { hrm.Msg = "用户不存在"; return hrm; }
                Article article = _ase.Article.FirstOrDefault(a => a.Uid == user.Id && a.Id == Convert.ToInt32(Request.Form["aid"]) && a.IsDelete == 0);
                if (article == null) { hrm.Msg = "文章不存在"; return hrm; }
                article.IsDelete = 1;
                if (_ase.SaveChanges() > 0)
                {
                    hrm.Code = 100;
                    hrm.Msg = "删除成功";
                }
                else
                {
                    hrm.Msg = "删除失败";
                }
            }
            catch (Exception e)
            {
                hrm.Msg = "删除文章错误";
            }
            return hrm;
        }

        /// <summary>
        /// 查询文章
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpReturnMod Get()
        {
            HttpReturnMod hrm = new HttpReturnMod();
            try
            {
                User user = _ase.User.FirstOrDefault(u => u.UserId.Equals(Request.Form["userid"]) && u.IsDelete == 0);
                if (user == null) { hrm.Msg = "用户不存在"; return hrm; }
                Article article = _ase.Article.FirstOrDefault(a => a.Uid == user.Id && a.Id == Convert.ToInt32(Request.Form["aid"]) && a.IsDelete == 0);
                if (article == null) { hrm.Msg = "文章不存在"; return hrm; }
                hrm.Dic.Add("data", JsonConvert.SerializeObject(article));
                hrm.Code = 100;
                hrm.Msg = "获取成功";
            }
            catch (Exception e)
            {
                hrm.Msg = "删除文章错误";
            }
            return hrm;
        }

        /// <summary>
        /// 获取我的文章列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpReturnMod MineList()
        {
            HttpReturnMod hrm = new HttpReturnMod();
            try
            {
                User user = _ase.User.FirstOrDefault(u => u.UserId.Equals(Request.Form["userid"]) && u.IsDelete == 0);
                if (user == null) { hrm.Msg = "用户不存在"; return hrm; }
                List<Article> list = _ase.Article.Where(a => a.Uid == user.Id && a.IsDelete == 0).OrderByDescending(a => a.CreateTime).ToList();
                hrm.Dic.Add("data", JsonConvert.SerializeObject(list));
                hrm.Code = 100;
                hrm.Msg = "获取成功";
            }
            catch (Exception e)
            {
                hrm.Msg = "获取我的文章列表错误";
            }
            return hrm;
        }

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpReturnMod List()
        {
            HttpReturnMod hrm = new HttpReturnMod();
            try
            {
                List<Dictionary<string, string>> listdic = new List<Dictionary<string, string>>();
                List<Article> list = _ase.Article.Where(a => a.IsDelete == 0).OrderByDescending(a => a.CreateTime).ToList();
                foreach (Article item in list)
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("Id", item.Id.ToString());
                    dic.Add("Uid", item.Uid.ToString());
                    dic.Add("Title", item.Title);
                    dic.Add("Content", ArticleContentIntercept(item.Content));
                    dic.Add("Classify", item.Classify);

                    string UserId = "-";
                    string UserAvatar = "-";
                    User user = _ase.User.FirstOrDefault(u => u.Id == item.Uid && u.IsDelete == 0);
                    if (user != null)
                    {
                        UserId = user.UserId;
                        UserAvatar = user.UserAvatar;
                    }
                    dic.Add("UserId", UserId);
                    dic.Add("UserAvatar", UserAvatar);
                    listdic.Add(dic);
                }
                hrm.Dic.Add("data", JsonConvert.SerializeObject(listdic));
                hrm.Code = 100;
                hrm.Msg = "获取成功";
            }
            catch (Exception e)
            {
                hrm.Msg = "获取文章列表错误";
            }
            return hrm;
        }

        /// <summary>
        /// 文章内容截断
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string ArticleContentIntercept(string content)
        {
            int startLength = 0;//起始长度
            int endLength = 100;//结束长度
            string endLang = "......";//结束长度后的结束语
            if (content.Length > endLength)
            {
                content = content.Substring(startLength, endLength) + endLang;
            }
            return content;
        }
    }
}
