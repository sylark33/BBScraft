using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiCraft;
using YiCraft.Models;

namespace YiCraft.Controllers
{
    public class mailController : Controller
    {
        // GET: mail
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string uid, string mail,string actualname,string idcard,string age)
        {
            if (Session["cheak1"].ToString() == "1")
            {
                Session["cheak1"] = "0";
                string YZM = YZMHelper.GetRandomString();
                Session["uid_1"] = uid;
                Session["YZM"] = YZM;
                Session["mail"] = mail.Trim();
                Session["actualname"] = actualname;
                Session["idcard"] = idcard;
                Session["age"] = age;
                bool end1 = YiMailHelper.Mail_Uid_exist(uid, Session["mail"].ToString());
                if (end1)
                {
                    if (YiMailHelper.Mail(mail, Session["YZM"].ToString()))
                    {
                        return View();
                    }
                    else
                    {
                        return Content("<script>alert('请输入正确的邮箱');window.location.href='../question/Index';</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('你输入的用户名或者邮箱已经被使用');window.location.href='../question/Index';</script>");
                }
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Add_End(string YZM)
        {
            if (Session["cheak2"].ToString() == "1")
            {
                Session["cheak2"] = "0";
                YiCraftCoreEntities2 db = new YiCraftCoreEntities2();
                if (Session["YZM"] != null && YZM.ToUpper() == Session["YZM"].ToString())
                {
                    yicraft_infos yi = new yicraft_infos();
                    yi.loginname = Session["uid_1"].ToString().Trim();
                    yi.mail = Session["mail"].ToString().Trim();
                    yi.actualname = Session["actualname"].ToString().Trim();
                    int temp = 0;
                    Int32.TryParse(Session["idcard"].ToString().Trim(), out temp);
                    yi.idcard = temp;
                    int temp1 = 0;
                    Int32.TryParse(Session["age"].ToString().Trim(), out temp1);
                    yi.age = temp1;
                    db.yicraft_infos.Add(yi);
                    db.SaveChanges();
                    if (temp1 < 80)
                    {
                        return Content("<script>alert('由于你的年龄未满80周岁，纳入意界防沉迷系统！恭喜！创建白名单成功！开始注册吧！');window.location.href='../Login/Index';</script>");
                    }
                    else
                    {
                        return Content("<script>alert('由于你的年龄大于80周岁，纳入意界养老防猝死系统系统！恭喜！创建白名单成功！开始注册吧！');window.location.href='../Login/Index';</script>");
                    }

                }
                else
                {
                    return Content("<script>alert('验证码错误，审核失败！请重新提交！');window.location.href='../question/Index';</script>");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}