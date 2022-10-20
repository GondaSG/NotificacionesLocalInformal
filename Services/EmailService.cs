using NotificationService.Entity;
using NotificationService.Services.Imp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NotificationService.Services
{
    public class EmailService : EmailImpService
    {
        private string email = "gdw.silvag@gmail.com";
        private string password = "poucmnthbmmrygqq";
        private int port = 587;
        private string host = "smtp.gmail.com";
        private string content = "";
        private string suject = "Locales informales por vencer en la región de {sregion}";
        public EmailService(IGrouping<string, Entity.Feature> t)
        {
            content = this.buildContent(t);
            suject = suject.Replace("{sregion}", t.Key);
        }
        public void SendEmail(string emails)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(email);
                message.To.Add(email);
                message.Subject = suject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = content;
                smtp.Port = port;
                smtp.Host = host; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(email, password);
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex ) { }
        }
        public string buildContent(IGrouping<string, Feature> t)
        {
            Feature[] aFeatures = t.ToArray();
            return "<h3 style='color: #2e6c80;'><span style='color: #000000;'><strong>Locales informales:</strong></span></h3>" +
                   "<p> Los siguientes locales informales estan cerca de su fecha de vencimiento.</p>" +
                   "<p> fecha de hoy "+ (DateTime.Now).AddDays(-60).ToShortDateString() +".</p>" +
                   "<table style = 'height: 36px; width: 80%; border-collapse: collapse; margin-left: auto; margin-right: auto;' border = '1'>" +
                   "<tbody>" +
                   "<tr style = 'height: 18px;' >" +
                   "<td style = 'width: 50%; height: 18px;'> Codigo Suministro </td>" +
                   "<td style = 'width: 50%; height: 18px;'> Fecha Vencimiento </td>" +
                   "</tr>" +
                    buildTr(aFeatures) +
                   "</tbody>" +
                   "</table>";
        }
        public string buildTr(Feature[] aFeatures) {
            string sTr = "";
            foreach (Feature f in aFeatures)
            {
                sTr += "<tr style = 'height: 18px;'>" +
                       "<td style = 'width: 50%; height: 18px;'> " + f.attributes.codSuministro + "</td>" +
                       "<td style = 'width: 50%; height: 18px;'> " + StrigToDataTime(f.attributes.EditDate).ToShortDateString() + "</td>" +
                       "</tr>";
            }
            return sTr;
        }

        private DateTime StrigToDataTime(string editDate)
        {
            long a = long.Parse(editDate);
            long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
            return new DateTime(beginTicks + a * 10000, DateTimeKind.Utc);
        }
    }
}
