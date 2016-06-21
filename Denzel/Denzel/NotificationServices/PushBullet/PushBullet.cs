using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.NotificationServices.PushBullet
{
    public class PushBullet
    {
        public string Token;

        public PushBullet()
        {

        }

        public PushBullet(string token)
        {
            Token = token;
        }

        public void Send(PushBulletPush push)
        {
            WebRequest request = WebRequest.Create("https://api.pushbullet.com/v2/pushes");
            request.Method = "POST";
            request.Headers.Add("Authorization", $"Bearer {Token}");
            request.ContentType = "application/json; charset=UTF-8";
            string postData = $"{{\"type\": \"link\", \"title\": \"{push.Title}\", \"body\": \"{push.Body}\", \"url\": \"{push.URL}\"}}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }
    }
}