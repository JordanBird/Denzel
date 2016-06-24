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
        private const string APIURL = "https://api.pushbullet.com/v2/pushes";
        public string Token;

        /// <summary>
        /// Instantiate PushBullet without a token. Please set Token after instantiation.
        /// </summary>
        public PushBullet()
        {

        }

        /// <summary>
        /// Instantiate PushBullet with a API token.
        /// </summary>
        /// <param name="token"></param>
        public PushBullet(string token)
        {
            SetToken(token);
        }

        public void SetToken(string token)
        {
            Token = token;
        }

        public void Send(PushBulletPush push)
        {
            var request = BuildRequest();
            var postData = BuildPostBody(push);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        private WebRequest BuildRequest()
        {
            WebRequest request = WebRequest.Create(APIURL);
            request.Method = "POST";
            request.Headers.Add("Authorization", $"Bearer {Token}");
            request.ContentType = "application/json; charset=UTF-8";

            return request;
        }

        private string BuildPostBody(PushBulletPush push)
        {
            return $"{{\"type\": \"link\", \"title\": \"{push.Title}\", \"body\": \"{push.Body}\", \"url\": \"{push.URL}\"}}";
        }
    }
}