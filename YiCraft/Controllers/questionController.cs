using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiCraft.Models;

namespace MVCmodel.Controllers
{
    public class questionController : Controller
    {
        YiCraftCoreEntities2 yi = new YiCraftCoreEntities2();
        Random sjs = new Random();
        // GET: question
        public ActionResult Index()
        {
            List<whitelistquestion_infos> listquest = new List<whitelistquestion_infos>();
            foreach (whitelistquestion_infos temp in yi.whitelistquestion_infos)
            {
                listquest.Add(temp);
            }
            for (int i = 0; i < listquest.Count; i++)
            {
                int j = sjs.Next(i, listquest.Count);
                whitelistquestion_infos temp = listquest[i];
                listquest[i] = listquest[j];
                listquest[j] = temp;
            }
            Session["listquest"] = listquest;
            Session["pagenumber"] = 0;
            return View();
        }
        public ActionResult questionlist()
        {
            if (Session["listquest"] == null)
            {
               
                //return Content("<script>alert('»Ø´ð´íÎó£¬ÇëÖØÐÂÉóºË');window.location.href='../question/Index';</script>");
               Index();

            }
            return View();
        }

    }
}


