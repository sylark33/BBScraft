using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using YiCraft.Models;



namespace YiCraft
{
   public static class YiMailHelper
    {
        public static bool Mail(string Mail_To, string Mail_Body)
        {
            string Mail_From = "454313500@qq.com";
            string Mail_Subject = "YiCraftCore意界白名单审核验证码";
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Mail_From);
                mailMessage.To.Add(new MailAddress(Mail_To));
                mailMessage.Subject = Mail_Subject;
                mailMessage.Body = Mail_Body;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.qq.com";
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Mail_From, "wwairzyjnfzgcbdi");
                client.Send(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //判断邮箱或者用户名是否存在
        public static bool Mail_Uid_exist(string uid,string mail)
        {
            YiCraftCoreEntities2 yce = new YiCraftCoreEntities2();
            var pm = from u in yce.yicraft_infos
                     where u.mail == mail || u.loginname == uid
                     select u;
          
                if (pm.Count()>0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }
    }
}
