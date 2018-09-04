using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Email
{
    public class SendSMS
    {
        public static string api_key = "caae08a9";
        public static string api_secret = "019cb71a0e7cf231";
        public string SMS(string to, string from, string text)
        {

            try
            {
                var url = new Uri("https://rest.nexmo.com/sms/json");
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                {
                    {"api_key", api_key },
                    {"api_secret", api_secret},
                     {"to", /*"66" + to.Substring(1, 9)*/to },
                     {"from", from },
                     {"text", text }
                };
                    var connects = new FormUrlEncodedContent(values);
                    var response = client.PostAsync(url, connects);
                    var data = response.Result.Content.ReadAsStringAsync().Result;

                    var JsonData = System.Web.Helpers.Json.Decode<m_SMS>(data);
                    if (JsonData.messages[0].status.Equals("0"))
                    {
                        return "Success";
                    }
                    return "Error";
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
    public class m_SMS
    {
        public List<messages> messages { get; set; }
    }

    public class messages
    {
        public string to { get; set; }
        public string status { get; set; }
    }
}
