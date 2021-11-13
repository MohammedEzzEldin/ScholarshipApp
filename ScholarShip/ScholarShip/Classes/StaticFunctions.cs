using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ScholarShip.Classes
{
    public static class StaticFunctions
    {
        public static SelectList ToSelectList(Dictionary<int, string> table)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in table)
            {
                list.Add(new SelectListItem() { Text = item.Value, Value = item.Key.ToString() });
            }

            return new SelectList(list, "Value", "Text");
        }
        public static int? GetSessionUserID(object session)
        {
            if (session != null && !Convert.ToString(session).Equals(string.Empty))
            {
                return Convert.ToInt32(session);
            }
            return null;
        }

        public static bool SendEmail(string receiverEmail, string subject, string body,ref string erroMsg)
        
        {
            try
            {
                WebMail.SmtpServer = ConstantVariables.SmtpServer;
                WebMail.SmtpPort = ConstantVariables.SmtpPort;
                WebMail.EnableSsl = true;
                WebMail.SmtpUseDefaultCredentials = true;
                WebMail.UserName = ConstantVariables.snederEamil;
                WebMail.Password = ConstantVariables.senderEmailtPassword;
                WebMail.From = ConstantVariables.snederEamil;
                WebMail.Send(receiverEmail, subject, body);
            }
            catch (Exception ex) { 
                erroMsg = ex.Message;
                return false;
            }
            return true;
        }
    }
}